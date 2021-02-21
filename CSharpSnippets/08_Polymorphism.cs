using CSharpSnippets.Business._08;
using System;
using System.Collections.Generic;

namespace CSharpSnippets
{
    public class _08_Polymorphism
    {
        public static void Run()
        {
            List<Animal> animals = new List<Animal>();

            var dog = new Dog("Beto", 25, "John House");
            Animal animal = AnimalFactory.Create(dog);
            Fruit fruit = new Fruit(3);
            Food food = FoodFactory.Create(fruit);
            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            animals.Add(animal);


            Tiger tiger = new Tiger("King", 650, "Forest", "Big Cat");
            animal = AnimalFactory.Create(tiger);
            Meat meat = new Meat(30);
            food = FoodFactory.Create(meat);
            try
            {
                animal.Eat(food);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            animals.Add(animal);

            foreach (var item in animals)
            {
                Console.WriteLine(item);
                Console.WriteLine("Sound: " + item.ProduceSound());
                Console.WriteLine("==============================================");
            }
        }
    }
}
