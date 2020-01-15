using DotaDrainCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotaDrainCore.DataRepository
{
    public interface IDataContext
    {
        Task<Match> InsertMatch(Match match);

        Task<Match> GetMatch(int id);

        Task<List<Match>> GetMatches();
        
        Task<BatchSizeConfiguration> UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration);

        Task<BatchSizeConfiguration> GetBatchSizeConfiguration();

    }
}
