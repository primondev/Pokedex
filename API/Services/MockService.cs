using API.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class MockService
    {
        private PokemonContext _context;
        public MockService(PokemonContext context)
        {
            _context = context;
        }
        public void Mock()
        {
            if (!_context.Types.Any())
            {
                _context.Types.AddRange(
                    new Entities.tbType(){ PokemonType = "tipo1"},
                    new Entities.tbType(){ PokemonType = "tipo2"},
                    new Entities.tbType(){ PokemonType = "tipo3"},
                    new Entities.tbType(){ PokemonType = "tipo4"},
                    new Entities.tbType(){ PokemonType = "tipo5"}
                );

                _context.SaveChanges();


            }

        }
    }
}
