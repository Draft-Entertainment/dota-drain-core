using DotaDrainCore.DataContext;
using DotaDrainCore.DataRepository;
using DotaDrainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotaDrainCore.EfDatabase
{
    public class EfDataRepository : IDataContext
    {
        private DotaDrainContext _context;
        private string v;

        public EfDataRepository(DotaDrainContext context)
        {
            _context = context;
        }

        public EfDataRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotaDrainContext>().UseSqlServer(connectionString).Options;
            _context = new DotaDrainContext(optionsBuilder);
        }

        public async Task<BatchSizeConfiguration> GetBatchSizeConfiguration()
        {
            var configurations = _context.BatchSizeConfigurations.FirstOrDefaultAsync();
            var result = await configurations ?? await InsertBatchSizeConfiguration(new BatchSizeConfiguration
            {
                Value = 20
            });
            return result;
        }

        public async Task<List<Match>> GetMatches()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<BatchSizeConfiguration> InsertBatchSizeConfiguration(BatchSizeConfiguration configuration)
        {
            var result = await _context.BatchSizeConfigurations.AddAsync(configuration);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Match> GetMatch(int id)
        {
            return await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Match> InsertMatch(Match match)
        {
            var result = await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<BatchSizeConfiguration> UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration)
        {
            _context.Entry(configuration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetBatchSizeConfiguration();
        }
    }
}
