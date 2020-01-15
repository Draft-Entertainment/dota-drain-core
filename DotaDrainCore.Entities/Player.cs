using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Design;

namespace DotaDrainCore.Entities
{
    public class Player: Entity
    {
        public uint PlayerId { get; set; }
        public uint SteamAccountId { get; set; }
        public string Name { get; set; }
        public bool HasDotaPlus { get; set; }
    }
}
