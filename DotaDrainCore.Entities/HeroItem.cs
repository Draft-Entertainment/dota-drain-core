using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class HeroItem: Entity
    {
        public TimeSpan AcquiringTime { get; set; }
        public Item Item { get; set; }
    }
}
