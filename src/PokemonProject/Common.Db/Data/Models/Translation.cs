using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Db.Data.Models
{
    public class Translation
    {
        public Guid Id { get; set; }
        public int PokemonId { get; set; }
        [ForeignKey("PokemonId")]
        public virtual Pokemon Pokemon { get; set; }
        public string TranslationCode { get; set; }
        public string Name { get; set; }
    }
}
