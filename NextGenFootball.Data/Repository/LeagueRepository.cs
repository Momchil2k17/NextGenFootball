﻿using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Repository
{
    public class LeagueRepository : BaseRepository<League, int>, ILeagueRepository
    {
        public LeagueRepository(NextGenFootballDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
