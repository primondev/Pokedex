using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Infra.Config
{
    public class TypeConfig : IEntityTypeConfiguration<tbType>
    {
        public void Configure(EntityTypeBuilder<tbType> builder)
        {

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.PokemonType).IsRequired().HasMaxLength(36);
            builder.HasIndex(p => p.PokemonType).IsUnique();
        


        }
    }
}
