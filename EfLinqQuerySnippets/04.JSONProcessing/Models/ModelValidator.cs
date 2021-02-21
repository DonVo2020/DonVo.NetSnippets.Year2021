namespace EfLinqQuerySnippets._04.JSONProcessing.Models
{
    public static class ModelValidator
    {
        public static class CarValidator
        {
            public const int MakeMaxLength = 30;

            public const int ModelMaxLength = 60;
        }

        public static class PartValidator
        {
            public const int NameMaxLength = 60;
        }

        public static class SupplierValidator
        {
            public const int NameMaxLength = 40;
        }

        public static class CustomerValidator
        {
            public const int NameMaxLength = 50;
        }
    }
}
