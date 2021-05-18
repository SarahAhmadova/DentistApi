using AutoMapper;
using ClientApi.Data.Entities;
using ClientApi.Infrastructure.Exceptions;
using ClientApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientApi.Controllers.V1
{
    [ApiVersion("1.0")]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService service)
        {
            _clientService = service;
        }


        [HttpGet]
        [Route("staff")]
        public async Task<IActionResult> GetStaffList()
        {
            var staffList = await _clientService.getStaffList();

            return Ok(staffList);
        }

        [HttpGet]
        [Route("services")]
        public async Task<IActionResult> GetServiceList()
        {
            var serviceList = await _clientService.getServiceList();

            return Ok(serviceList);
        }

        [HttpPost]
        [Route("appointment")]
        public async Task<IActionResult> addAppointment([FromBody]AppointmentResource appointment)
        {
            if (!ModelState.IsValid) return BadRequest(appointment);
            try
            {
                var _app = await _clientService.addAppointment(appointment);
                return Ok(_app);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

    }
}
