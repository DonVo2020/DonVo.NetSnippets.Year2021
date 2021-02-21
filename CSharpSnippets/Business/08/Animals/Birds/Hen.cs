
using System.Collections.Generic;

namespace CSharpSnippets.Business._08
{
    public class Hen : Bird
    {
        private const double GainValue = 0.35;

        public Hen(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            this.BaseEat(food, new List<string>() { nameof(Meat), nameof(Fruit), nameof(Seeds), nameof(Vegetable), }, GainValue);
        }

        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}

