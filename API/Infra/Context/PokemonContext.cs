using API.Entities;
using API.Infra.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Context
{
    public class PokemonContext : DbContext
    {

        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {



        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonConfig());

            modelBuilder.ApplyConfiguration(new PokemonTypeConfig());

            modelBuilder.ApplyConfiguration(new TypeConfig());

        }


        public DbSet<tbPokemon> Pokemons { get; set; }
        public DbSet<tbPokemonType> PokemonTypes { get; set; }
        public DbSet<tbType> Types { get; set; }
    }
}
