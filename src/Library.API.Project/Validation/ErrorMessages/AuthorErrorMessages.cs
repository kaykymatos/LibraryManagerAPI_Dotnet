namespace Library.Project.API.Validation.ErrorMessages
{
    public static class AuthorErrorMessages
    {
        public readonly static string EmptyName = "O campo {PropertyName} não pode ser nulo!";
        public readonly static string MinLengthName = "O Tamanho mínimo do campo {PropertyName} deve ser de 5 caracteres!";
        public readonly static string MaxLengthName = "O Tamanho máximo do campo {PropertyName} é de 50 caracteres!";

        public readonly static string EmptyBirthDate = "O campo {PropertyName} não deve ser Nulo!";
        public readonly static string BirthDateLessThan18 = "O Autor deve ter 18 anos ou mais para ser cadastrado!";
        public readonly static string AuthorNameHasBeRegistred = "O Autor ja foi cadastrado!";
    }
}
