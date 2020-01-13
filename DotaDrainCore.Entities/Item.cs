using System;
namespace DotaDrainCore.Entities
{
    public class Item: Entity
    {
        public Player Player { get; set; }
        public int ExternalId { get; set; }
        public TimeSpan AcquiringTime { get; set; }
    }
}
