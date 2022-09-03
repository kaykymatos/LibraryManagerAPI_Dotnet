namespace Library.Project.API.Validation.ErrorMessages
{
    public static class BookErrorMessages
    {
        public readonly static string EmptyTitle = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string MinLengthTitle = "O tamanho mínimo do campo {PropertyName} é de 5 caracteres!";
        public readonly static string MaxLengthTitle = "O tamanho máximo do campo {PropertyName} é de 20 caracteres!";

        public readonly static string EmptyDescription = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string MinLengthDescription = "O tamanho mínimo do campo {PropertyName} é de 10 caracteres!";
        public readonly static string MaxLengthDescription = "O tamanho máximo do campo {PropertyName} é de 150 caracteres!";

        public readonly static string EmptyLauchDate = "O data do campo {PropertyName} não pode ser nula!";
        public readonly static string FutureLaunchDate = "A data do campo {PropertyName} não pode ser futura!";

        public readonly static string EmptyAuthorId = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string AuthorIdLength = "O campo Id do autor deve ser maior que 0!";

        public readonly static string AuthorIdNotExists = "O campo {PropertyName} não foi encontrado no banco de dados!";

    }
}
