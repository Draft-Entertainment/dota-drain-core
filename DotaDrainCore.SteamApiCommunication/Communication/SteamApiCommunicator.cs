using DotaDrainCore.Entities;
using Steam.Models.DOTA2;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using DotaDrainCore.Entities.Enumerations;

namespace DotaDrainCore.SteamApiCommunication.Communication
{
    public class SteamApiCommunicator
    {
        private SteamWebInterfaceFactory _interfaceFactory;

        public SteamApiCommunicator(string apiKey)
        {
            _interfaceFactory = new SteamWebInterfaceFactory(apiKey);
        }

        public async IAsyncEnumerable<Match> GetMatches(int batchSize, ulong startAtMatch = 0)
        {
            var dota2Interaface = _interfaceFactory.CreateSteamWebInterface<DOTA2Match>(new HttpClient());

            List<MatchHistoryMatchModel> allMatches = new List<MatchHistoryMatchModel>();

            uint matchesCount = 0;
            do
            {
                MatchHistoryModel matches = (await dota2Interaface.GetMatchHistoryAsync(
                    gameMode: 22, // ranked
                    startAtMatchId: startAtMatch)).Data;
                allMatches.AddRange(matches.Matches);

                if (matches.ResultsRemaining <= 0)
                    break;

                matchesCount += matches.NumResults;
                startAtMatch = matches.Matches.Min(m => m.MatchId);
            } while (matchesCount < batchSize);

                

            var dota2EconomyInteraface = _interfaceFactory.CreateSteamWebInterface<DOTA2Econ>(new HttpClient());
            var heroes = (await dota2EconomyInteraface.GetHeroesAsync()).Data;
            var items = (await dota2EconomyInteraface.GetGameItemsAsync()).Data;


            List<Match> mappedMatches = new List<Match>();

            foreach (var match in allMatches.Take(batchSize))
            {
                var matchDetails = (await dota2Interaface.GetMatchDetailsAsync(match.MatchId)).Data;
                if (matchDetails != null)
                    yield return new Match()
                    {
                        StartDate = matchDetails.StartTime,
                        ExternalMatchId = match.MatchId,
                        Winner = matchDetails.RadiantWin ? Side.Radiant : Side.Dire,
                        MatchHistory = matchDetails.Players.Select(p => new PlayerMatchHistory()
                        {
                            Kills = (int)p.Kills,
                            Deaths = (int)p.Assists,
                            Assists = (int)p.Assists,
                            Side = (((int)p.PlayerSlot & 128) == 128) ? Side.Dire : Side.Radiant,
                            Hero = new Hero()
                            {
                                ExternalId = p.HeroId,
                                Name = heroes.FirstOrDefault(h => h.Id == p.HeroId)?.LocalizedName
                            },
                            Items = new List<uint> { p.Item0, p.Item1, p.Item2, p.Item3, p.Item4, p.Item5 }
                                .Where(p => p != 0)
                                .Select(i => new HeroItem()
                                {
                                    Item = new Item()
                                    {
                                        ExternalId = i,
                                        Name = items.FirstOrDefault(it => it.Id == i).LocalizedName
                                    }
                                }).ToList(),
                            Player = new Player()
                            {
                                PlayerId = p.AccountId,
                                SteamAccountId = p.AccountId
                            }
                        }).ToList()
                    };
            }
        }
    }
}
