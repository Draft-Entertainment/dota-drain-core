using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Net.Http;
using System.Linq;
using DotaDrainCore.SteamApiCommunication.Communication;
using DotaDrainCore.SteamApiCommunication.Models;
using DotaDrainCore.DataRepository;
using DotaDrainCore.EfDatabase;
using Microsoft.Extensions.Configuration;
using System.IO;
using DotaDrainCore.DataContext;

namespace DotaDrainCore.SteamDataCollector
{
    class Program
    {
        private static IConfiguration _configuration;
        private static IDataContext _dataRepository;

        static async System.Threading.Tasks.Task Main(string[] args)
        {

            // TODO:
            // Load configuration and create repository
            GetAppSettingsFile();


            SteamApiCommunicator communicator = new SteamApiCommunicator("F402A8BD4427CA62314326C7F7BAF435");
            var bs = _dataRepository.GetBatchSizeConfiguration().Result.Value;
            var matches = await communicator.GetMatches(bs);

            // TODO:
            foreach(var match in matches)
                await _dataRepository.InsertMatch(match);


            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            _dataRepository = new EfDataRepository(_configuration.GetConnectionString("DotaDrainContext"));
        }
    }
}
