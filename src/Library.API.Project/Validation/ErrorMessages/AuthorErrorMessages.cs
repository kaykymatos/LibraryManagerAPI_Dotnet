namespace Library.API.Project.Validation.ErrorMessages
{
    public static class AuthorErrorMessages
    {
        public static string EmptyName = "O campo {PropertyName} não pode ser nulo!";
        public static string MinLengthName = "O Tamanho mínimo do campo {PropertyName} deve ser de 5 caracteres!";
        public static string MaxLengthName = "O Tamanho máximo do campo {PropertyName} é de 50 caracteres!";

        public static string EmptyBirthDate = "O campo {PropertyName} não deve ser Nulo!";
        public static string BirthDateLessThan18 = "O Autor deve ter 18 anos ou mais para ser cadastrado!";

    }
}
