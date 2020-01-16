using DotaDrainCore.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class PlayerMatchHistory : Entity
    {
        public int PlayerId { get; set; }
        public virtual Player Player { get; set; }
        public int HeroId { get; set; }
        public virtual Hero Hero { get; set; }
        public Side Side { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
        public int MatchId { get; set; }
        public virtual Match Match { get; set; }
        public virtual List<ItemPlayerMatchHistory> ItemPlayerMatchHistories { get; set; }
    }
}
