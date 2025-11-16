using System;

namespace AnimalApp.Models
{
    public class Dog : Animal
    {
        public override string Species => "Koer";

        public Dog(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Auh-auh!";
        }

        public override string Feed()
        {
            return $"{Species} {Name} sai kondi.";
        }
    }
}