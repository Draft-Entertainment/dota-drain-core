using DotaDrainCore.DataRepository;
using DotaDrainCore.Entities;
using System;

namespace DotaDrainCore.Factories
{
    public class SystemConfigurationFactory
    {
        private IDataContext dataContext;
        public SystemConfigurationFactory()
        {
            
        }

        public BatchSizeConfiguration GetBatchSizeConfigurationConfiguration()
        {
            return dataContext.GetBatchSizeConfiguration();
        }
    }
}
