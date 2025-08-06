using NextGenFootball.Data.Models;
using NextGenFootball.Data.Repository.Interfaces;
using NextGenFootball.Services.Core.Interfaces;
using NextGenFootball.Web.ViewModels.RefereeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenFootball.Services.Core
{
    public class RefereeService : IRefereeService
    {
        private readonly IRefereeRepository refereeRepository;
        public RefereeService(IRefereeRepository refereeRepository)
        {
            this.refereeRepository = refereeRepository;
        }

        public async Task<bool> CreateRefereeAsync(RefereeCreateViewModel model)
        {
            bool res = false;
            Referee? referee = new Referee
            {
                ApplicationUserId = model.ApplicationUserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ImageUrl = model.ImageUrl
            };
            await this.refereeRepository.AddAsync(referee);
            res = true;
            return res;
        }

        public async Task<bool> EditRefereeAsync(RefereeEditViewModel model)
        {
            bool res= false;
            Referee? referee = await this.refereeRepository
                .FirstOrDefaultAsync(r => r.Id == model.Id);
            if (referee != null)
            {
                referee.FirstName = model.FirstName;
                referee.LastName = model.LastName;
                referee.PhoneNumber = model.PhoneNumber;
                referee.Email = model.Email;
                referee.ImageUrl = model.ImageUrl;
                referee.ApplicationUserId = model.ApplicationUserId;
                await this.refereeRepository.UpdateAsync(referee);
                res = true; 
            }
            return res;
        }

        public async Task<IEnumerable<RefereeIndexViewModel>?> GetAllRefereesAsync()
        {
            IEnumerable<RefereeIndexViewModel>? result = null;
            result=this.refereeRepository
                .GetAllAttached()
                .Select(r=> new RefereeIndexViewModel
                {
                    Id = r.Id,
                    FirstName = r.FirstName,
                    LastName = r.LastName,
                    PhoneNumber = r.PhoneNumber,
                    Email = r.Email
                });
            return result;

        }

        public async Task<RefereeEditViewModel?> GetRefereeByForEdit(Guid? id)
        {
            RefereeEditViewModel? referee = null;
            bool isValidGuid = id.HasValue && id.Value != Guid.Empty;
            if (isValidGuid) 
            {
                Referee? referee1 = await this.refereeRepository
                    .FirstOrDefaultAsync(r => r.Id == id.Value);
                if (referee1 != null)
                {
                    referee = new RefereeEditViewModel
                    {
                        Id = referee1.Id,
                        FirstName = referee1.FirstName,
                        LastName = referee1.LastName,
                        PhoneNumber = referee1.PhoneNumber,
                        Email = referee1.Email,
                        ImageUrl = referee1.ImageUrl,
                        ApplicationUserId = referee1.ApplicationUserId
                    };
                }
            }
            return referee;
        }
    }
}
