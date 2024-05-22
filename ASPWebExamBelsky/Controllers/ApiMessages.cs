namespace ASPWebExamBelsky.Controllers
{
    // ApiMessages - класс, включающий описание сообщений API в виде рекордов (record)
    public class ApiMessages
    {
        // StringMessage - сообщение со строкой
        public record StringMessage(string Message);

        // RegisterMessage - сообщение для регистрации пользователя
        public record RegisterMessage(string Login);

        // ApiKeyMessage - сообщение для хранения api-ключа
        public record ApiKeyMessage(string ApiKey);

        // ErrorMessage - сообщение с информацией об ошибках
        public record ErrorMessage(string ErrorType, string Message);
    }
}
