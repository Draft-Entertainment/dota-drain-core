using DotaDrainCore.DataRepository;
using DotaDrainCore.Entities;
using System;
using System.Threading.Tasks;

namespace DotaDrainCore.Factories
{
    public class SystemConfigurationFactory
    {
        private IDataContext dataContext;
        public SystemConfigurationFactory()
        {

        }

        public async Task<BatchSizeConfiguration> GetBatchSizeConfigurationConfiguration()
        {
            return await dataContext.GetBatchSizeConfiguration();
        }
    }
}
