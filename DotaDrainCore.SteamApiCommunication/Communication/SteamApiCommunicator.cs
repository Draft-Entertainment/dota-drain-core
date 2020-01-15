using DotaDrainCore.SteamApiCommunication.Models;
using SteamWebAPI2.Interfaces;
using SteamWebAPI2.Utilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace DotaDrainCore.SteamApiCommunication.Communication
{
    public class SteamApiCommunicator
    {
        private SteamWebInterfaceFactory _interfaceFactory;

        public SteamApiCommunicator(string apiKey)
        {
            _interfaceFactory = new SteamWebInterfaceFactory(apiKey); //"F402A8BD4427CA62314326C7F7BAF435"
        }

        public void GetMatches(RangeList rangeList)
        {
            try
            {
                var dota2Interaface = _interfaceFactory.CreateSteamWebInterface<DOTA2Match>(new HttpClient());
                //var maches = (await dota2Interaface.GetMatchHistoryAsync(gameMode: 1, startAtMatchId: 0)).Data;
            }
            catch (Exception exception)
            {
            
            }
        }
    }
}
