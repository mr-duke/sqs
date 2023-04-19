namespace PokemonApp.Models
{
    public class DummyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public DummyClass() { }

        public DummyClass(int number, string name)
        {
            Number = number;
            Name = name;
        }
    }
}

