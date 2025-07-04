﻿using NextGenFootball.Web.ViewModels.Match;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core.Interfaces
{
    public interface IMatchService
    {
        public Task<IEnumerable<MatchIndexViewModel>> GetAllMatchesAsync();
    }
}
