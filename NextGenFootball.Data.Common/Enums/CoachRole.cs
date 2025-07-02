using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Data.Common.Enums
{
    public enum CoachRole
    {
        [Display(Name = "Head Coach")]
        HeadCoach =1,

        [Display(Name = "Assistant Coach")]
        AssistantCoach =2,

        [Display(Name = "Goalkeeper Coach")]
        GoalkeeperCoach =3,

        [Display(Name = "Fitness Coach")]
        FitnessCoach =4,

        [Display(Name = "Analyst")]
        Analyst =5
    }
}
