using Common.Db.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Db.Dto
{
    public class PokemonDtoList
    {
        public ICollection<PokemonDto> Pokemons { get; set; }
    }

    public class PokemonDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public BaseStatDto Stats { get; set; }
        public ICollection<PokemonTypeDto> PokemonTypes { get; set; }
        public ICollection<TranslationDto> Translations { get; set; }
    }


    public class BaseStatDto
    {
        public int PokemonId { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
    }

    public class PokemonTypeDto
    {
        public string TypeName { get; set; }
    }

    public class TranslationDto
    {
        public int PokemonId { get; set; }
        public string TranslationCode { get; set; }
        public string Name { get; set; }
    }

    public class TranslationDtoList
    {
        public ICollection<TranslationDto> Translations { get; set; }
    }
}
