using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Net.Http;
using System.Linq;

namespace DotaDrainCore.SteamDataCollector
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            var webInterfaceFactory = new SteamWebInterfaceFactory("F402A8BD4427CA62314326C7F7BAF435");

            
            var dota2Interaface = webInterfaceFactory.CreateSteamWebInterface<DOTA2Match>(new HttpClient());
            var match = (await dota2Interaface.GetMatchDetailsAsync((await dota2Interaface.GetMatchHistoryAsync(gameMode: 1, startAtMatchId: 0)).Data.Matches.FirstOrDefault().MatchId)).Data;
            

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
