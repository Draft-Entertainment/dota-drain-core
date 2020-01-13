using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class Hero : Entity
    {
        public int ExternalId { get; set; }
        public string Name { get; set; }
        // Base64 formatted image
        public string Icon { get; set; }
    }
}
