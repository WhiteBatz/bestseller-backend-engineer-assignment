using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Db.Data.Models
{
    public class BaseStat
    {
        public Guid Id { get; set; }
        public int PokemonId { get; set; }
        [ForeignKey("PokemonId")]
        public virtual Pokemon Pokemon { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }
    }
}
