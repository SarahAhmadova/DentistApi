using AutoMapper;
using MedicApp.Data.Entities.Admin;
using MedicApp.Infrastructure.Exceptions;
using MedicApp.Infrastructure.FileManager;
using MedicApp.Infrastructure.Filter;
using MedicApp.Resource.Staff;
using MedicApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicApp.Controllers.V1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(Auth))]
    public class StaffController : BaseController
    {
        private readonly IStaffService _staffService;
        private readonly ICloudinaryService _cloudinary;
        private readonly IFileManager _fileManager;
        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetStaffList()
        {
            var staffList = await _staffService.getStaffList();

            //var staffResources = _mapper.Map<IEnumerable<Staff>, IEnumerable<StaffResource>>(staffList);

            return Ok(staffList);
        }


        // CREATE STAFF
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateStaff([FromBody] AddStaffResource resource)
        {

            if (!ModelState.IsValid) return BadRequest(resource);

            try
            {
                var _staff = _mapper.Map<AddStaffResource, Staff>(resource);

            var staff = await _staffService.addStaff(_staff);

                var staffResource = _mapper.Map<Staff, AddStaffResource>(staff);

                return Ok(staffResource);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }


        // PUT api/<StaffController>/5
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStaff([FromRoute] int id, [FromBody] Staff staff)
        {
           
            if (!ModelState.IsValid) return BadRequest(staff);

            try
            {
                await _staffService.updateStaff(id,staff);
                return Ok("Updated");
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        // DELETE api/<StaffController>/5
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _staffService.deleteStaff(id);
                return NoContent();
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        
    }
}
