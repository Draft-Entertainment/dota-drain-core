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
            // Do not write match without players
            if (match.PlayerMatchHistories.Any(m => m.HeroId == 0 && m.Hero == null))
                return null;

            List<PlayerMatchHistory> playerMatchHistories = new List<PlayerMatchHistory>();

            match.PlayerMatchHistories.ForEach(p => {
                playerMatchHistories.Add(new PlayerMatchHistory(p));

                p.Hero = null;
                p.ItemPlayerMatchHistories = null;
                p.Player = null;
            });

            var matchFormDb = (await _context.Matches.AddAsync(match)).Entity;
            await _context.SaveChangesAsync();


            playerMatchHistories.ForEach(playerMatchHistory =>
            {
                playerMatchHistory.MatchId = matchFormDb.Id;

                // TODO : refactor
                var heroFromDb = playerMatchHistory.Hero != null ? _context.Heroes.FirstOrDefault(hero => hero.ExternalId == playerMatchHistory.Hero.ExternalId) : null;
                if (heroFromDb != null)
                {
                    playerMatchHistory.HeroId = heroFromDb.Id;
                    playerMatchHistory.Hero = null;
                }

                playerMatchHistory.ItemPlayerMatchHistories.ForEach(itemPlayerMatchHistory => {
                    
                    var itemFromDb = _context.Items.FirstOrDefault(item => item.ExternalId == itemPlayerMatchHistory.Item.ExternalId);

                    if (itemFromDb == null)
                    {
                        itemFromDb = (_context.Items.Add(new Item() {
                            ExternalId = itemPlayerMatchHistory.Item.ExternalId,
                            Name = itemPlayerMatchHistory.Item.Name
                        })).Entity;
                        _context.SaveChanges();
                    }
                    itemPlayerMatchHistory.ItemId = itemFromDb.Id;
                    itemPlayerMatchHistory.Item = null;
                });

                var playerFromDb = _context.Players.FirstOrDefault(player => player.PlayerId == playerMatchHistory.Player.PlayerId);
                if (playerFromDb != null)
                {
                    playerMatchHistory.PlayerId = playerFromDb.Id;
                    playerMatchHistory.Player = null;
                }

            });

            await _context.PlayerMatchHistories.AddRangeAsync(playerMatchHistories);
            await _context.SaveChangesAsync();



            return matchFormDb;
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

        public async Task<List<PlayerMatchHistory>> GetPlayerMatchHistoryByMatchId(int matchId)
        {
            return (await _context.PlayerMatchHistories.ToListAsync()).Where(p => p.MatchId == matchId).ToList();
        }
    }
}
