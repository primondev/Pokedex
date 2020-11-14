using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class tbPokemon
    {
        public Guid Id { get; set; }
        public int Pokedex_Index { get; set; }

        public string Name { get; set; }

        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }

        public int Special_Attack { get; set; }
        public int Special_Defense { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }

        public ICollection<tbPokemonType> PokemonTypes { get; set; }
    }
}
