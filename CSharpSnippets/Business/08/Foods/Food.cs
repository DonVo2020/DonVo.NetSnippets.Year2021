namespace CSharpSnippets.Business._08
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}

