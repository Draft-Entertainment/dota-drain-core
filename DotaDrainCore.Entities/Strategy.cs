using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class Strategy : Entity
    {
        public List<Hero> SuggestedHeroes { get; set; }
    }
}
