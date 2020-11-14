using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class tbPokemonType
    {
        public Guid Id { get; set; }
        public tbPokemon Pokemon { get; set; }
        public tbType Type { get; set; }

    }
}
