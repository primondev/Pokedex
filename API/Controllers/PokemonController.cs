using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Helpers;
using API.Infra.Context;
using API.Models.Pokemon;
using API.Models.User;
using API.Models.UserTeste;
using API.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private PokemonContext _context;
        private IConfiguration _configuration;
        private PokemonValidator _pokemonValidator;
        public PokemonController(PokemonContext context,IConfiguration configuration, PokemonValidator validator)
        {
            _context = context;
            _configuration = configuration;
            _pokemonValidator = validator;
        }

        [HttpGet]       
        public IActionResult GetAll()
        {

            List<PokemonResponse> response = new List<PokemonResponse>();

            response = _context.Pokemons.Include(p => p.PokemonTypes)
                                        .ThenInclude(p => p.Type)
                                        .Select(p => PokemonResponse.GeneratePokemonResponse(p))
                                        .ToList();

            return Ok(response);
        }

        [HttpGet("Token")]
        public IActionResult GetToken()
        {
            UserTeste user = new UserTeste()
            {
                Name = "Marco Antonio Primon",
                Type = UserType.Admin

            };

            string token = JwtAuth.GenerateToken(user, _configuration.GetValue<string>("SystemKey"));

            return Ok(token);
        }

        [HttpPost]
        [Authorize(Roles ="User")]        
        public async Task<IActionResult> Create([FromBody]CreatePokemonRequest request)
        {
            try
            {
                tbPokemon pokemon = new tbPokemon { 
                    Attack = request.Attack,
                    Defense = request.Defense,
                    Special_Attack = request.Special_Attack,
                    Generation = request.Generation,
                    Hp = request.Hp,
                    Name = request.Name ,
                    Pokedex_Index = request.Pokedex_Index,
                    Special_Defense = request.Special_Defense,
                    Speed = request.Speed                    
                };

                List<tbType> Types = _context.Types.Where(p => request.Types.Contains(p.PokemonType)).ToList();

                pokemon.PokemonTypes = Types.Select(p => new tbPokemonType() { 

                    Pokemon = pokemon,
                    Type = p

                }).ToList();

                var teste = _pokemonValidator.Validate(pokemon);

                _context.Add(pokemon);

                await _context.SaveChangesAsync();

                PokemonResponse response = PokemonResponse.GeneratePokemonResponse(pokemon);

                return Created("", response);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
