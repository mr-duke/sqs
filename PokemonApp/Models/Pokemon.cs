namespace PokemonApp.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public string ImageUrl { get; set; }

        public Pokemon() { }

        public Pokemon(int number, string name, string type1, string type2, string imageUrl)
        {
            Number = number;
            Name = name;
            Type1 = type1;
            Type2 = type2;
            ImageUrl = imageUrl;
        }
    }
}
