using DataLayer.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace CRUD_WebAPI_Dependency_Injection_ASPDOTNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInformationController : ControllerBase
    {
        private readonly IPersonalInformationService personalInformationService;

        public PersonalInformationController(IPersonalInformationService personalInformationService)
        {
            this.personalInformationService = personalInformationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPersonalInformations()
        {
            var information = await this.personalInformationService.GetAllPersonalInformations();
            return Ok(information);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPersonalInformationById(int Id)
        {
            var information = await this.personalInformationService.GetPersonalInformationById(Id);
            return Ok(information);
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonalInformation(PersonalInformationDTO personalInformation)
        {
            if (ModelState.IsValid)
            {
                await this.personalInformationService.AddPersonalInformation(personalInformation);
                return Ok("Added");
            }
            else
            {
                return BadRequest(ModelState);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePersonalInformation(int p_Id, PersonalInformationDTO personalInformation)
        {
            await this.personalInformationService.UpdatePersonalInformation(p_Id, personalInformation); 
            return Ok("Updated");
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePersonalInformation(int p_Id)
        {
            await this.personalInformationService.DeletePersonalInformation(p_Id);
            return Ok("Deleted");
        }
    }
}
