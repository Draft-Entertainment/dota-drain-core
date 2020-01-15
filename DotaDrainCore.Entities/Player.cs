using System;
using System.ComponentModel.DataAnnotations;

namespace DotaDrainCore.Entities
{
    public class Player: Entity
    {
        public int PlayerId { get; set; }
        public int SteamAccountId { get; set; }
        public string Name { get; set; }
        public bool HasDotaPlus { get; set; }
    }
}
