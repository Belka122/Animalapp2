using System;

namespace AnimalApp.Models
{
    // Интерфейс для всех кормимых животных
    public interface IFeedable
    {
        string Feed();
    }

    // Базовый абстрактный класс Животного
    public abstract class Animal : IFeedable
    {
        public string Name { get; set; }
        public int Age { get; set; }

        // Вид животного (кошка, собака и т.д.)
        public abstract string Species { get; }

        protected Animal(string name, int age)
        {
            Name = name;
            Age = age;
        }

        // Звук животного
        public abstract string MakeSound();

        // Кормление — базовая реализация
        public virtual string Feed()
        {
            return $"{Species} {Name} sõi toitu.";
        }

        public override string ToString()
        {
            return $"{Species} {Name}, {Age} a.";
        }
    }
}