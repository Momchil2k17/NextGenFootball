using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.RefereeManagement
{
    public class RefereeEditViewModel : RefereeCreateViewModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
