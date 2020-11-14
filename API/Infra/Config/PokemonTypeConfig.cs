using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Config
{
    public class PokemonTypeConfig : IEntityTypeConfiguration<tbPokemonType>
    {
        public void Configure(EntityTypeBuilder<tbPokemonType> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

           
            builder.HasOne(p => p.Type).WithMany(p => p.PokemonTypes);

            builder.HasOne(p => p.Pokemon).WithMany(p => p.PokemonTypes);
            
        }
    }
}
