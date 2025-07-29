using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Seeding.Interfaces
{
    public interface IIdentitySeeder
    {
        Task SeedIdentityAsync();
    }
}
