using DotaDrainCore.Factories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaDrainCore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemConfigurationController : ControllerBase
    {
        private SystemConfigurationFactory systemConfigurationFactory = new SystemConfigurationFactory();

        [HttpGet]
        [Route("[action]")]
        public int Get()
        {
            var batchSize = systemConfigurationFactory.GetBatchSizeConfigurationConfiguration();
            return batchSize.Result.Value;
        }
    }
}
