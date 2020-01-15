using DotaDrainCore.Entities;
using System;
using System.Threading.Tasks;

namespace DotaDrainCore.DataRepository
{
    public class DataRepository
    {
        IDataContext _dataContext;

        public DataRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Match> InsertMatchAsync(Match match)
        {
            return await _dataContext.InsertMatchAsync(match);
        }

        public async Task<Match> GetMatchAsync(int id)
        {
            return await _dataContext.GetMatch(id);
        }

        public async Task<BatchSizeConfiguration> UpdateBatchSizeConfigurationAsync(BatchSizeConfiguration configuration)
        {
            return await _dataContext.UpdateBatchSizeConfiguration(configuration);
        }

        public async Task<BatchSizeConfiguration> getBatchSizeConfigurationAsync()
        {
            return await _dataContext.GetBatchSizeConfiguration();
        }

    }
}
