namespace AnimalApp.Models
{
    public enum Species { Dog, Cat, Bird, Other }
    public class Animal
    {
        public string Name { get; set; } = string.Empty;
        public Species Species { get; set; }
        public int Age { get; set; }
        public string? Notes { get; set; }
    }
}
