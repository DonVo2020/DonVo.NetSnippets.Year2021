
namespace CSharpSnippets.Business._08
{
    public static class AnimalFactory
    {
        public static Animal Create<T>(T animal)
        {
            string type = animal.GetType().Name;

            if (type == nameof(Hen))
            {
                var hen = animal as Hen;
                return new Hen(hen.Name, hen.Weight, hen.WingSize);
            }
            else if (type == nameof(Owl))
            {
                var owl = animal as Owl;
                return new Owl(owl.Name, owl.Weight, owl.WingSize);
            }
            else if (type == nameof(Mouse))
            {
                var mouse = animal as Mouse;
                return new Mouse(mouse.Name, mouse.Weight, mouse.LivingRegion);
            }
            else if (type == nameof(Dog))
            {
                var dog = animal as Dog;
                return new Dog(dog.Name, dog.Weight, dog.LivingRegion);
            }
            else if (type == nameof(Cat))
            {
                var cat = animal as Cat;
                return new Cat(cat.Name, cat.Weight, cat.LivingRegion, cat.Breed);
            }
            else if (type == nameof(Tiger))
            {
                var tiger = animal as Tiger;
                return new Tiger(tiger.Name, tiger.Weight, tiger.LivingRegion, tiger.Breed);
            }

            return null;
        }
    }
}

