using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Config
{
    public class PokemonConfig : IEntityTypeConfiguration<tbPokemon>
    {
        public void Configure(EntityTypeBuilder<tbPokemon> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Pokedex_Index).IsRequired();
            builder.HasIndex(p => p.Pokedex_Index).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(36);
            builder.HasIndex(p => p.Name).IsUnique();


            builder.Property(p => p.Hp).IsRequired();
            builder.Property(p => p.Attack).IsRequired();
            builder.Property(p => p.Defense).IsRequired();
            builder.Property(p => p.Special_Attack).IsRequired();
            builder.Property(p => p.Special_Defense).IsRequired();
            builder.Property(p => p.Speed).IsRequired();
            builder.Property(p => p.Generation).IsRequired();

          


        }
    }
}
