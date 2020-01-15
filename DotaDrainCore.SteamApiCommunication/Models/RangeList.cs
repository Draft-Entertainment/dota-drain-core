using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DotaDrainCore.SteamApiCommunication.Models
{
    public class RangeList
    {
        public List<Range> List { get; set; }
        public int MatchCount { get; set; }


        public RangeList()
        {
            List = new List<Range>();
        }

        public RangeList Regroup()
        {
            for (int i = 0; i < List.Count; )
            {
                var range = List.Except(new List<Range>() { List[i] }).FirstOrDefault(r =>
                    (r.FromMatchId >= List[i].FromMatchId && r.FromMatchId <= List[i].ToMatchId)
                    || (r.ToMatchId >= List[i].FromMatchId && r.ToMatchId <= List[i].ToMatchId));
                if (range != null)
                {
                    var mergedRange = new Range(
                        Math.Min(range.FromMatchId, List[i].FromMatchId),
                        Math.Max(range.ToMatchId, List[i].ToMatchId));

                    List.RemoveAt(i);
                    List.RemoveAt(List.FindIndex(r => r == range));

                    List.Add(mergedRange);

                    i = 0;
                }
                else
                {
                    i++;
                }
            }
            return this;
        }
    }
}
