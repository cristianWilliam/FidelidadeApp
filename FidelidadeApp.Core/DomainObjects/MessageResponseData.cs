namespace FidelidadeApp.Core.DomainObjects
{
    public class MessageResponseData<T> : MessageResponse where T : class
    {
        public T Dados { get; private set; }

        public MessageResponseData(bool successo, T dados, string mensagem = "") : base(successo, mensagem)
        {
            Dados = dados;
        }

        public static MessageResponseData<T> Ok(T dados, string mensagem = "") => 
            new MessageResponseData<T>(true, dados, mensagem);

        public static MessageResponseData<T> Erro(string mensagem = "", T dados = null) =>
           new MessageResponseData<T>(false, dados, mensagem);
    }
}
