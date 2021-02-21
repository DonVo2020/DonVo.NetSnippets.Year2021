
using System;
using System.Collections.Generic;

namespace CSharpSnippets.Business._08
{
    public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
            this.FoodEaten = 0;
        }

        public string Name { get; private set; }

        public double Weight { get; protected set; }

        public int FoodEaten { get; protected set; }

        public abstract string ProduceSound();

        public abstract void Eat(Food food);

        protected void BaseEat(Food food, List<string> eatableFood, double gainValue)
        {
            string typeFood = food.GetType().Name;

            if (!eatableFood.Contains(typeFood))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {typeFood}!");
            }

            this.Weight += food.Quantity * gainValue;
            this.FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, ";
        }
    }
}

