namespace Library.API.Project.Validation.ErrorMessages
{
    public static class BookErrorMessages
    {
        public static string EmptyTitle = "O campo {PropertyName} não pode ser nulo!";
        public static string MinLengthTitle = "O tamanho mínimo do campo {PropertyName} é de 5 caracteres!";
        public static string MaxLengthTitle = "O tamanho máximo do campo {PropertyName} é de 20 caracteres!";

        public static string EmptyDescription = "O campo {PropertyName} não pode ser nulo!";
        public static string MinLengthDescription = "O tamanho mínimo do campo {PropertyName} é de 10 caracteres!";
        public static string MaxLengthDescription = "O tamanho máximo do campo {PropertyName} é de 100 caracteres!";

        public static string EmptyLauchDate = "O data do campo {PropertyName} não pode ser nula!";
        public static string FutureLaunchDate = "A data do campo {PropertyName} não pode ser futura!";

        public static string EmptyAuthorId = "O campo {PropertyName} não pode ser nulo!";
        public static string AuthorIdLength = "O campo Id do autor deve ser maior que 0!";

        public static string AuthorIdNotExists = "O campo {PropertyName} não foi encontrado no banco de dados!";

    }
}
