using DotaDrainCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotaDrainCore.DataRepository
{
    public interface IDataContext
    {
        Task<Match> InsertMatchAsync(Match match);
        Task<Match> GetMatch(int id);

        Task<BatchSizeConfiguration> UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration);
        Task<BatchSizeConfiguration> GetBatchSizeConfiguration();

    }
}
