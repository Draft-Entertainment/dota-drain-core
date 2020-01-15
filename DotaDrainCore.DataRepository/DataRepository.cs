using DotaDrainCore.Entities;
using System;

namespace DotaDrainCore.DataRepository
{
    public class DataRepository
    {
        IDataContext _dataContext;

        public DataRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Match InsertMatch(Match match)
        {
            return _dataContext.InsertMatch(match);
        }

        public Match GetMatch(int id)
        {
            return _dataContext.GetMatch(id);
        }

        public BatchSizeConfiguration UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration)
        {
            return _dataContext.UpdateBatchSizeConfiguration(configuration);
        }

        public BatchSizeConfiguration getBatchSizeConfiguration()
        {
            return _dataContext.GetBatchSizeConfiguration();
        }

    }
}
