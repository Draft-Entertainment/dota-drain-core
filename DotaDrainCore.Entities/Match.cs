using DotaDrainCore.Entities.Enumerations;
using System;
using System.Collections.Generic;

namespace DotaDrainCore.Entities
{
    public class Match : Entity
    {
        public uint ExternalMatchId { get; set; }
        public DateTime? EndDate { get; set; }
        public GameVersion Patch { get; set; }
        public List<PlayerMatchHistory> MatchHistory { get; set; }
        public Side Winner { get; set; }
    }
}
