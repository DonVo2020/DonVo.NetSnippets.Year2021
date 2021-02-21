namespace EfLinqQuerySnippets._04.JSONProcessing.DTOs
{
    public class SalesDiscountDTO
    {
        public CarMakeModelDistanceDTO Car { get; set; }

        public string CustomerName { get; set; }

        public int Discount { get; set; }

        public decimal Price { get; set; }

        public decimal PriceWithDiscount { get; set; }
    }
}
