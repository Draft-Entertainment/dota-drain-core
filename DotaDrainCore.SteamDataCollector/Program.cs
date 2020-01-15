using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Net.Http;
using System.Linq;
using DotaDrainCore.SteamApiCommunication.Communication;
using DotaDrainCore.SteamApiCommunication.Models;
using DotaDrainCore.DataRepository;

namespace DotaDrainCore.SteamDataCollector
{
    class Program
    {

        private static DataRepository.DataRepository _dataRepository;

        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // TODO:
            // Create instance of data repository
            // _dataRepository = new ???();


            SteamApiCommunicator communicator = new SteamApiCommunicator("F402A8BD4427CA62314326C7F7BAF435");
            var matches = await communicator.GetMatches(10 /*_dataRepository.getBatchSizeConfiguration().Value*/);

            // TODO:
            //foreach(var match in matches)
            //    _dataRepository.InsertMatch(match);


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
