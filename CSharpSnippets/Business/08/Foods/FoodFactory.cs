namespace CSharpSnippets.Business._08
{
    public static class FoodFactory
    {
        public static Food Create(Food food)
        {
            string type = food.GetType().Name;
            int quantity = food.Quantity;

            if (type == nameof(Vegetable))
            {
                return new Vegetable(quantity);
            }
            else if (type == nameof(Seeds))
            {
                return new Seeds(quantity);
            }
            else if (type == nameof(Meat))
            {
                return new Meat(quantity);
            }
            else if (type == nameof(Fruit))
            {
                return new Fruit(quantity);
            }

            return null;
        }
    }
}

