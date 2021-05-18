using MedicApp.Data.Entities.Admin;
using MedicApp.Infrastructure.Exceptions;
using MedicApp.Infrastructure.Filter;
using MedicApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Controllers.V1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(Auth))]
    public class AppointmentController : BaseController
    {
        private readonly IAppointmentService _service;
        public AppointmentController(IAppointmentService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("appointment-requests")]
        public async Task<IActionResult> getClientAppointments()
        {
            var appointments = await _service.getClientAppointments();
            return Ok(appointments);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> getAppointments()
        {
            var appointments = await _service.getAdminAppointments();
            return Ok(appointments);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> addAppointment([FromBody] Appointments appointment)
        {
            if (!ModelState.IsValid) return BadRequest(appointment);

            try
            {
                 var _appointment = await _service.addAppointment(appointment);
                 return Ok(_appointment);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
           
        }
    }
}
