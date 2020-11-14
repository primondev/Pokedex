using API.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Validators
{
    public class PokemonValidator : AbstractValidator<tbPokemon>
    {

        public PokemonValidator()
        {
            RuleFor(p => p.Name).MaximumLength(36).NotNull().OnAnyFailure(p => throw new Exception("Algo errado com o Nome"));
            RuleFor(p => p.Pokedex_Index).NotNull().OnAnyFailure(p => throw new Exception("O valor Pokedex_Index não pode ser nulo"));
            RuleFor(p => p.Hp).NotNull().OnAnyFailure(p => throw new Exception("O valor HP não pode ser nulo"));
            RuleFor(p => p.Attack).NotNull().OnAnyFailure(p => throw new Exception("O valor Attack não pode ser nulo"));
            RuleFor(p => p.Defense).NotNull().OnAnyFailure(p => throw new Exception("O valor Defense não pode ser nulo"));
            RuleFor(p => p.Speed).NotNull().OnAnyFailure(p => throw new Exception("O valor Speed não pode ser nulo"));
            RuleFor(p => p.Special_Attack).NotNull().OnAnyFailure(p => throw new Exception("O valor Special_Attack não pode ser nulo"));
            RuleFor(p => p.Special_Defense).NotNull().OnAnyFailure(p => throw new Exception("O valor Special_Defense não pode ser nulo"));
            RuleFor(p => p.Generation).NotNull().OnAnyFailure(p => throw new Exception("O valor Generation não pode ser nulo"));


        }


    }
}
