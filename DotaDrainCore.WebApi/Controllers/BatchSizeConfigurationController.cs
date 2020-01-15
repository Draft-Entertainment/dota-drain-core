using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotaDrainCore.DataContext;
using DotaDrainCore.Entities;
using DotaDrainCore.EfDatabase;

namespace DotaDrainCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BatchSizeConfigurationController : ControllerBase
    {
        private readonly DotaDrainContext _context;
        private readonly EfDataRepository _dataRepository;

        public BatchSizeConfigurationController(DotaDrainContext context)
        {
            _context = context;
            _dataRepository = new EfDataRepository(_context);
        }


        // GET: api/BatchSizeConfiguration
        [HttpGet]
        public async Task<ActionResult<BatchSizeConfiguration>> Get()
        {
            var batchSizeConfiguration = await _dataRepository.GetBatchSizeConfiguration();

            if (batchSizeConfiguration == null)
            {
                return NotFound();
            }

            return batchSizeConfiguration;
        }

        // PUT: api/BatchSizeConfiguration/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<ActionResult<BatchSizeConfiguration>> PutBatchSizeConfiguration(int id, BatchSizeConfiguration batchSizeConfiguration)
        {
            if (id != batchSizeConfiguration.Id)
            {
                return BadRequest();
            }            

            return await _dataRepository.UpdateBatchSizeConfiguration(batchSizeConfiguration);
        }

        // POST: api/BatchSizeConfiguration
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BatchSizeConfiguration>> PostBatchSizeConfiguration(BatchSizeConfiguration batchSizeConfiguration)
        {
            _context.BatchSizeConfigurations.Add(batchSizeConfiguration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBatchSizeConfiguration", new { id = batchSizeConfiguration.Id }, batchSizeConfiguration);
        }        
    }
}
