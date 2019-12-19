using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaDrainCore.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SystemConfigurationController : ControllerBase
    {
        [HttpGet]
        [Route("[action]")]
        public int GetBatchSizeConfiguration()
        {
            return 1000;
        }
    }
}
