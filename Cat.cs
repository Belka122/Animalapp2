using System;

namespace AnimalApp.Models
{
    public class Cat : Animal
    {
        public override string Species => "Kass";

        public Cat(string name, int age) : base(name, age)
        {
        }

        public override string MakeSound()
        {
            return "Mjäu!";
        }

        public override string Feed()
        {
            return $"{Species} {Name} sai kala.";
        }
    }
}