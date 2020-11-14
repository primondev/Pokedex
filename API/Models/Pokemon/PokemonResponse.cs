using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Pokemon
{
    public class PokemonResponse
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

        public decimal Total { get; set; }

        public string[] Types { get; set; }


        public static PokemonResponse GeneratePokemonResponse(tbPokemon pokemon)
        {
            return new PokemonResponse()
            {
                Id = pokemon.Id,
                Attack = pokemon.Attack,
                Special_Attack = pokemon.Special_Attack,
                Defense = pokemon.Special_Defense,
                Generation = pokemon.Generation,
                Hp = pokemon.Hp,
                Name = pokemon.Name,
                Pokedex_Index = pokemon.Pokedex_Index,
                Special_Defense = pokemon.Special_Defense,
                Speed = pokemon.Speed,
                Total = pokemon.Speed + pokemon.Attack + pokemon.Special_Attack + pokemon.Special_Defense + pokemon.Hp + pokemon.Defense,
                Types = pokemon.PokemonTypes.Select(p => p.Type.PokemonType).ToArray()
            };




        }
    }
}
