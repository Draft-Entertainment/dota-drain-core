using DotaDrainCore.Entities.Enumerations;
using System;
using System.Collections.Generic;

namespace DotaDrainCore.Entities
{
    public class Match : Entity
    {
        public ulong ExternalMatchId { get; set; }
        public DateTime? StartDate { get; set; }
        public Side Winner { get; set; }
        public List<PlayerMatchHistory> MatchHistory { get; set; }
    }
}
