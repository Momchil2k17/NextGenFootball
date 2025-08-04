using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Web.ViewModels.Admin.UserManagement
{
    public class UserManagementIndexViewModel
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
