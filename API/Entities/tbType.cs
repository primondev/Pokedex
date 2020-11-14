using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class tbType
    {

        public Guid Id { get; set; }       
        public string PokemonType { get; set; }

        public ICollection<tbPokemonType> PokemonTypes { get; set; }
    }
}
