using DotaDrainCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotaDrainCore.DataRepository
{
    public interface IDataContext
    {
        Match InsertMatch(Match match);
        Match GetMatch(int id);

        BatchSizeConfiguration UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration);
        BatchSizeConfiguration GetBatchSizeConfiguration();

    }
}
