using DotaDrainCore.Entities.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class PlayerMatchHistory: Entity
    {
        public Player Player { get; set; }
        public Hero Hero { get; set; }
        public List<HeroItem> Items { get; set; }
        public Side Side { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Assists { get; set; }
    }
}
