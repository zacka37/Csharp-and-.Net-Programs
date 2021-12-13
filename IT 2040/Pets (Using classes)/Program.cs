using System;

namespace Pets
{
    class Program
    {
        static void Main(string[] args)
        {
            Pet pet1 = new Pet("dog", "Shadow", "Jose", 42.6);

            Console.WriteLine("Name: " + pet1.getName());
            Console.WriteLine("Weight: " + pet1.getWeight());
            Console.WriteLine(pet1.getTag());
            Console.WriteLine("-----------------------");
            Dog dog1 = new Dog("Daisy", "Kent", 23.4);

            Console.WriteLine("Name: " + dog1.getName());
            Console.WriteLine("Weight: " + dog1.getWeight());
            Console.WriteLine(dog1.getTag());
            Console.WriteLine(dog1.bark(4));
            Console.WriteLine("-----------------------");
            Cat cat1 = new Cat("Simba", "Maria", 5.2);

            Console.WriteLine("Name: " + cat1.getName());
            Console.WriteLine("Weight: " + cat1.getWeight());
            Console.WriteLine(cat1.getTag());
            Console.WriteLine(cat1.meow(3));
        }
    }
}
