using System;
using System.Collections.Generic;

namespace CSharpSnippets
{
    public class _09_DictionaryCollections
    {
        public void Start()
        {
            Numbers();
            Countries();
            Do("+");
            Do("*");
            Do("/");
            Do("-");
        }

        private void Numbers()
        {
            Dictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(10, "Ten");
            numberNames.Add(20, "Twenty");
            numberNames.Add(30, "Thirty");
            foreach (KeyValuePair<int, string> kvp in numberNames)
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        }

        private void Countries()
        {
            var continents = new Dictionary<string, string>(){
                {"America", "Brazil, Chile, Argentina"},
                {"Europe", "Ireland, Italy, Spain"},
                {"Asia", "China, Japan, Thailand"}
            };
            Console.WriteLine(continents["Asia"]);

            continents.Remove("Europe"); // removes Europe 

            if (continents.ContainsKey("America"))
            {
                Console.WriteLine(continents["America"]);
            }

            if (continents.TryGetValue("Asian", out string result))
            {
                Console.WriteLine(result);
            }
        }

        private void Do(string parameter)
        {
            var actions = new Dictionary<string, Action<int, int>>(){
                {"+", Add},
                {"-", Substract},
                {"/", Divide},
                {"*", Multiply}
            };
            actions[parameter].Invoke(10, 5);
        }

        private void Add(int valueA, int valueB)
        {
            Console.WriteLine("Add.." + (valueA + valueB));
        }

        private void Substract(int valueA, int valueB)
        {
            Console.WriteLine("Substract..." + (valueA - valueB));
        }

        private void Divide(int valueA, int valueB)
        {
            Console.WriteLine("Divide.." + (valueA / valueB));
        }

        private void Multiply(int valueA, int valueB)
        {
            Console.WriteLine("Multiply.." + (valueA * valueB));
        }
    }
}
