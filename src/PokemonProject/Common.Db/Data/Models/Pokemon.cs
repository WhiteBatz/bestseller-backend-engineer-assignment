using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Db.Data.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual BaseStat Stats { get; set; }
        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
        public virtual ICollection<Translation> Translations { get; set; }
    }
}
