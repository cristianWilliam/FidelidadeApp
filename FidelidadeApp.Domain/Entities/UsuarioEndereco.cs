using FidelidadeApp.Core.Models;
using System;

namespace FidelidadeApp.Domain.Entities
{
    public class UsuarioEndereco : Entity
    {
        public Guid UsuarioId { get; private set; }

        public Endereco Endereco { get; private set; }

        // Ef navigation Property
        public virtual AuthUsuario Usuario { get; private set; }

        protected UsuarioEndereco() { }

        public UsuarioEndereco(Guid id, Guid usuarioId, Endereco endereco)
        {
            Id = id;
            UsuarioId = usuarioId;
            Endereco = endereco;
        }

        public void AlterarEndereco(Endereco endereco)
        {
            this.Endereco = endereco;
        }
    }
}
