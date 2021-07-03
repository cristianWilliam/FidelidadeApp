namespace FidelidadeApp.Core.DomainObjects
{
    public class MessageResponse
    {
        public bool Successo { get; private set; }
        public string Mensagem { get; private set; }

        public MessageResponse(bool successo, string mensagem)
        {
            Successo = successo;
            Mensagem = mensagem;
        }

        public static MessageResponse Ok(string mensagem = "") => new MessageResponse(true, mensagem);
        public static MessageResponse Erro(string mensagem = "") => new MessageResponse(false, mensagem);
    }
}
