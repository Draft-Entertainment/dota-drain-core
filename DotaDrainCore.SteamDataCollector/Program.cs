using System;
using DotaDrainCore.SteamApiCommunication.Communication;
using DotaDrainCore.DataRepository;
using DotaDrainCore.EfDatabase;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace DotaDrainCore.SteamDataCollector
{
    class Program
    {
        private static IConfiguration _configuration;
        private static IDataContext _dataRepository;
        private static bool _continueWorking;

        protected static string Key {
            get { return _configuration.GetValue<string>("SteamApiKey"); }
        }
        protected static TimeSpan TimeBetweenRequests {
            get
            {
                return new TimeSpan(0, _configuration.GetValue<int>("TimeBetweenRequestsMinutes"), 0);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Steam data collector starting");

            // Load configuration and create repository
            GetAppSettingsFile();

            Console.WriteLine("Steam data collector getting data");
            _continueWorking = true;
            // Data getting thread (get from api, save to db)
            StartDataGetThread();

            // Logic exit
            string answer = "";
            do
            {
                Console.WriteLine("To exit write 'stop'");
                answer = Console.ReadLine();
            } while (answer != "stop");
            _continueWorking = false;

            // End
            Console.WriteLine("Steam data collector terminating");
        }

        private static async void StartDataGetThread() {
            DateTime lastWorkTime = new DateTime();
            while (_continueWorking) {
                if (DateTime.Now > lastWorkTime + TimeBetweenRequests)
                {
                    await GetAndWriteMatches();
                    lastWorkTime = DateTime.Now;
                }
                Thread.Sleep(1000);
            }
        }

        private static async Task GetAndWriteMatches()
        {
            try
            {
                SteamApiCommunicator communicator = new SteamApiCommunicator(Key);
                int batchSize = _dataRepository.GetBatchSizeConfiguration().Result.Value;
                var matches = communicator.GetMatches(batchSize);


                await foreach (var match in matches)
                {
                    if (!(await _dataRepository.CheckMatchExistance(match.ExternalMatchId)))
                    {
                        await _dataRepository.InsertMatch(match);
                        Console.WriteLine("Match {0} inserted", match.ExternalMatchId);
                    }
                    else
                    {
                        Console.WriteLine("Match {0} skipped", match.ExternalMatchId);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Cant write match");
                Console.WriteLine(exception.Message);
            }
        }

        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();
            _dataRepository = new EfDataRepository(_configuration.GetConnectionString("DotaDrainContext"));
        }
    }
}
