using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotaDrainCore.Entities
{
    public class Match : Entity
    {
        [Key]
        public int ExternalMatchId { get; set; }
        public DateTime? EndDate { get; set; }
        public GameVersion Patch { get; set; }
        public ICollection<Hero> EnemyHeroes { get; set; }
        public ICollection<Hero> TeamHeroes { get; set; }
        public ICollection<Item> Items { get; set; }
        public bool DireWon { get; set; }
    }
}
