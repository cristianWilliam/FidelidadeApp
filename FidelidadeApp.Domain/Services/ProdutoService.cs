using AutoMapper;
using FidelidadeApp.Core.DomainObjects;
using FidelidadeApp.Core.Models;
using FidelidadeApp.Domain.Abstractions;
using FidelidadeApp.Domain.Entities;
using FidelidadeApp.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FidelidadeApp.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IProdutoRepository produtoRepository, IMapper mapper, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProdutoVM>> ObterDisponiveis()
        {
            return _mapper.Map<IEnumerable<ProdutoVM>>(await _produtoRepository.ObterDisponiveisResgate());
        }

        public async Task<MessageResponse> RegatarProduto(Guid usuarioId, Guid produtoId)
        {
            try
            {
                var produto = await _produtoRepository.ObterPorIdComVenda(produtoId);

                if (produto == null)
                    throw new ProdutoNaoEncontradoException();

                if (produto.ProdutoVenda != null)
                    return MessageResponse.Erro("Produto nao esta mais disponivel");

                var usuarioSaldo = await _usuarioRepository.ObterSaldo(usuarioId);
                var usuarioEndereco = await _usuarioRepository.ObterComEndereco(usuarioId);

                if (usuarioEndereco.EnderecoEntrega == null)
                    return MessageResponse.Erro("Usuario sem endereco de entrega cadastrado");

                if (usuarioSaldo.Saldo == null || usuarioSaldo.Saldo.PontosAtuais < produto.ValorPontos)
                    return MessageResponse.Erro("Saldo insuficiente");

                var movimentacao = UsuarioExtratoMovimentacao.ExtratoMovimentacaoFactory
                                        .VenderProduto(usuarioId, produto, usuarioEndereco.EnderecoEntrega.Endereco);

                usuarioSaldo.AddExtrato(movimentacao);
                usuarioSaldo.Saldo.DebitarSaldo(produto.ValorPontos);
                produto.Vender(movimentacao.Id, usuarioEndereco.EnderecoEntrega.Endereco);

                await _unitOfWork.Commit();

                return MessageResponse.Ok();
            }
            catch (DomainException ex)
            {
                return MessageResponse.Erro(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public async Task<IEnumerable<ProdutoStatusEntregaVM>> ObterTodosComStatusEntrega()
        {
            return _mapper.Map<IEnumerable<ProdutoStatusEntregaVM>>(await _produtoRepository.ObterTodosComStatusVenda());
        }
    }
}
