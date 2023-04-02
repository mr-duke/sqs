using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Text.Json;

namespace PokemonApp.Models
{
    public class PokemonDTO
    {
        public string Name { get; set; }
        public int Number { get; set; }
        public string ImageUrl { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }

        public PokemonDTO(HttpResponseMessage response)
        {
            var json = response.Content.ReadAsStringAsync().Result;
            var pokemon = JObject.Parse(json);

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            Name = textInfo.ToTitleCase(pokemon["name"].ToString());
            Number = int.Parse(pokemon["id"].ToString());
            ImageUrl = pokemon["sprites"]["front_default"].ToString();
            Type1 = textInfo.ToTitleCase(pokemon["types"][0]["type"]["name"].ToString());
            Type2 = pokemon["types"].Count() > 1 ? textInfo.ToTitleCase(pokemon["types"][1]["type"]["name"].ToString()) : "None";
        }
    }
}
