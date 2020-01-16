﻿using System;
using System.Collections.Generic;

namespace DotaDrainCore.Entities
{
    public class Item: Entity
    {
        public uint ExternalId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public virtual List<PlayerMatchHistory> PlayerMatchHistories { get; set; }
        public virtual List<Strategy> Strategies { get; set; }
    }
}
