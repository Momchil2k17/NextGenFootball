using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Models
{
    [Comment("Represents a football season.")]
    public class Season
    {
        [Comment("Unique identifier for the season.")]
        public int Id { get; set; }
        [Comment("Name of the season, e.g., '2023/2024'.")]
        public string Name { get; set; } =null!;
        [Comment("Start date of the season.")]
        public DateTime StartDate { get; set; }
        [Comment("End date of the season.")]
        public DateTime EndDate { get; set; }
        [Comment("Indicates whether the season is the current one.")]
        public bool IsCurrent { get; set; }
    }
}
