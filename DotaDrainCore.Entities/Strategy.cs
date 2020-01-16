using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class Strategy : Entity
    {
        public virtual List<Hero> SuggestedHeroes { get; set; }
        public virtual List<Item> SuggestedItems { get; set; }
    }
}
