using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.SteamApiCommunication.Models
{
    public class Range
    {
        public ulong FromMatchId { get; set; }
        public ulong ToMatchId { get; set; }

        public Range(ulong fromMatchId, ulong toMatchId) {
            FromMatchId = fromMatchId;
            ToMatchId = toMatchId;
        }

        public override bool Equals(object obj)
        {
            Range anotherRange = obj as Range;
            if (anotherRange == null)
                return false;
            return FromMatchId == anotherRange.FromMatchId
                && ToMatchId == anotherRange.ToMatchId;
        }

        public override int GetHashCode()
        {
            return FromMatchId.GetHashCode() + ToMatchId.GetHashCode();
        }
    }
}
