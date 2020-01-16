using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class ItemPlayerMatchHistory : Entity
    {
        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
        public int PlayerMatchHistoryId { get; set; }
        public virtual PlayerMatchHistory PlayerMatchHistory { get; set; }
    }
}
