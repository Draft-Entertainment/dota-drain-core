using DotaDrainCore.Entities;
using System;

namespace DotaDrainCore.Factories
{
    public class SystemConfigurationFactory
    {
        private IDataService dataService;
        public SystemConfigurationFactory()
        {
            dataService = dataService.GetInstance();
        }

        public BatchSizeConfiguration GetBatchSizeConfigurationConfiguration()
        {
            return dataService<BatchSizeConfiguration>.Get();
        }
    }
}
