using NextGenFootball.Data.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Player
{
    public class PlayerForCoachSquad
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

        public string PreferredFoot { get; set; } = null!;
        public string? ImageUrl { get; set; }

        public string Position { get; set; } = null!;
        public PositionEnum PositionEnum { get; set; }

    }
}
