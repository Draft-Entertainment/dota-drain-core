using DotaDrainCore.DataContext;
using DotaDrainCore.DataRepository;
using DotaDrainCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaDrainCore.EfDatabase
{
    public class EfDataRepository : IDataContext
    {
        private DotaDrainContext _context;

        public EfDataRepository(DotaDrainContext context)
        {
            _context = context;
        }

        public EfDataRepository(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DotaDrainContext>().UseSqlServer(connectionString).Options;
            _context = new DotaDrainContext(optionsBuilder);
            _context.Database.EnsureCreated();
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
            match.MatchHistory.ForEach(matchHistory =>
            {
                // TODO : refactor
                var heroFromDb = matchHistory.Hero != null ? _context.Heroes.FirstOrDefault(hero => hero.ExternalId == matchHistory.Hero.ExternalId) : null;
                if (heroFromDb != null)
                {
                    matchHistory.HeroId = heroFromDb.Id;
                    matchHistory.Hero = null;
                }
                matchHistory.ItemPlayerMatchHistories.ForEach(itemPlayerMatchHistory => {
                    
                    var itemFromDb = _context.Items.FirstOrDefault(item => item.ExternalId == itemPlayerMatchHistory.Item.ExternalId);

                    if (itemFromDb != null)
                    {
                        itemPlayerMatchHistory.ItemId = itemFromDb.Id;
                    }
                });

                var playerFromDb = _context.Players.FirstOrDefault(player => player.PlayerId == matchHistory.Player.PlayerId);

                if (playerFromDb != null)
                {
                    matchHistory.PlayerId = playerFromDb.Id;
                    matchHistory.Player = null;
                }

            });

            // Do not write match without players
            if (match.MatchHistory.Any(m => m.HeroId == 0 && m.Hero == null))
                return null;

            var result = await _context.Matches.AddAsync(match);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> CheckMatchExistance(ulong externalMatchId)
        {
            return await _context.Matches.AnyAsync(m => m.ExternalMatchId == externalMatchId);
        }
        
        public async Task<BatchSizeConfiguration> UpdateBatchSizeConfiguration(BatchSizeConfiguration configuration)
        {
            _context.Entry(configuration).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await GetBatchSizeConfiguration();
        }
    }
}
