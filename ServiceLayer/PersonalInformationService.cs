
using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IPersonalInformationService
    {
        Task<IEnumerable<PersonalInformationDTO>> GetAllPersonalInformations();
        Task<PersonalInformationDTO> GetPersonalInformationById(int p_Id);
        Task AddPersonalInformation(PersonalInformationDTO personalInformation);
        Task UpdatePersonalInformation(int p_Id, PersonalInformationDTO personalInformation);
        Task DeletePersonalInformation(int p_Id);
    }
    public class PersonalInformationService : IPersonalInformationService
    {
        private readonly PersonalInformationDBContext dBContext;
        public PersonalInformationService(PersonalInformationDBContext dbContext)
        {
            this.dBContext = dbContext;
        }
        public async Task AddPersonalInformation(PersonalInformationDTO personalInformation)
        {
            PersonalInformation personal = new();

            personal.Id = personalInformation.Id;
            personal.Name = personalInformation.Name;
            personal.Address = personalInformation.Address;
            personal.PhoneNumber = personalInformation.PhoneNumber;

            await this.dBContext.PersonalInformation.AddAsync(personal);
            await this.dBContext.SaveChangesAsync();
        }

        public async Task DeletePersonalInformation(int p_Id)
        {
            var information = await this.dBContext.PersonalInformation.FindAsync(p_Id);
            if (information != null)
            {
                this.dBContext.PersonalInformation.Remove(information);

                await this.dBContext.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<PersonalInformationDTO>> GetAllPersonalInformations()
        {
            return await this.dBContext.PersonalInformation
                .Select(x => new PersonalInformationDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber
                }).ToListAsync();
        }

        public async Task<PersonalInformationDTO> GetPersonalInformationById(int p_Id)
        {
            var information = await this.dBContext.PersonalInformation
                .Select(x => new PersonalInformationDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    PhoneNumber = x.PhoneNumber
                }).FirstOrDefaultAsync(xx => xx.Id == p_Id);
            if (information != null)
                return information;
            return new PersonalInformationDTO();

        }

        public async Task UpdatePersonalInformation(int p_Id, PersonalInformationDTO personalInformation)
        {
            var information = await this.dBContext.PersonalInformation.FindAsync(p_Id);

            if (information != null)
            {
                information.Name = personalInformation.Name;
                information.Address = personalInformation.Address;
                information.PhoneNumber = personalInformation.PhoneNumber;

                await this.dBContext.SaveChangesAsync();
            }
        }
    }
}
