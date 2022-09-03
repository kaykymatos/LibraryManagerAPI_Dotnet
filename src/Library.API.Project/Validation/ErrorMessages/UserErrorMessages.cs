namespace Library.Project.API.Validation.ErrorMessages
{
    public static class UserErrorMessages
    {
        public readonly static string EmptyName = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string NameMinLength = "O Tamanho mínimo do campo {PropertyName} deve ser de 5 caracteres!";
        public readonly static string NameMaxLength = "O Tamanho máximo do campo {PropertyName} é de 50 caracteres!";

        public readonly static string EmptyEmail = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string EmailMinLength = "O Tamanho mínimo do campo {PropertyName} deve ser de 5 caracteres!";
        public readonly static string EmailMaxLength = "O Tamanho máximo do campo {PropertyName} é de 100 caracteres!";
        public readonly static string EmailExists = "O email informado já esta cadastrado!";

        public readonly static string EmptyPassword = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string PasswordMinLength = "O Tamanho mínimo do campo {PropertyName} deve ser de 8 caracteres!";
        public readonly static string PasswordMaxLength = "O Tamanho máximo do campo {PropertyName} é de 100 caracteres!";

        public readonly static string EmptyBirthDate = "O campo {PropertyName} não deve ser Nulo!";
        public readonly static string BirthDateLessThan18 = "O Usuário deve ter 18 anos ou mais para ser cadastrado!";

    }
}
