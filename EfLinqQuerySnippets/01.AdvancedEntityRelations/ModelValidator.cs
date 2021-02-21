namespace EfLinqQuerySnippets._01.AdvancedEntityRelations
{
    public static class ModelValidator
    {
        public static class UserValidator
        {
            public const int NameMaxLength = 50;

            public const int EmailMaxLength = 80;

            public const int PasswordMaxLength = 25;
        }

        public static class BankAccountValidator
        {
            public const int BankNameMaxLength = 50;

            public const int SwiftCodeMaxLength = 25;
        }
    }
}
