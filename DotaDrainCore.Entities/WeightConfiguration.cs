using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class WeightConfiguration : Entity
    {
        public double EnemyHeroWeight { get; set; }
        public double SelfHeroWeight { get; set; }
        public double TeamHeroWeight { get; set; }
        public double ItemRate { get; set; }
    }
}
