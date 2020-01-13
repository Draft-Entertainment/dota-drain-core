using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotaDrainCore.Entities
{
    public class GameVersion : Entity
    {
        public string PatchName { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
}
