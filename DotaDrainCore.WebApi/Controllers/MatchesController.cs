using DotaDrainCore.DataContext;
using DotaDrainCore.DataRepository;
using DotaDrainCore.EfDatabase;
using DotaDrainCore.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaDrainCore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController: ControllerBase
    {
        private readonly DotaDrainContext _context;
        private readonly IDataContext _dataContext;
        public MatchesController(DotaDrainContext context)
        {
            _context = context;
            _dataContext = new EfDataRepository(_context);
        }

        [HttpGet]
        public async Task<ActionResult<List<Match>>> Get()
        {
            var matches = await _dataContext.GetMatches();
            return matches;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Match>> Get(int id)
        {
            if(id == 0)
            {
                NotFound();
            }

            return await _dataContext.GetMatch(id);
        }
    }
}
