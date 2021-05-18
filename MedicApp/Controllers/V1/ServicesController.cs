using MedicApp.Data.Entities.Admin;
using MedicApp.Infrastructure.Exceptions;
using MedicApp.Infrastructure.Filter;
using MedicApp.Resource.Medservices;
using MedicApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicApp.Controllers.V1
{
    [ApiVersion("1.0")]
    [TypeFilter(typeof(Auth))]

    public class ServicesController : BaseController
    {
        private readonly IMedserviceService _services; 
        public ServicesController(IMedserviceService services)
        {
            _services = services;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddService([FromBody] Medservices service)
        {
            if (!ModelState.IsValid) return BadRequest(service);

            try
            {
                var _service = await _services.addService(service);
                return Ok(_service);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateService([FromRoute] int id, [FromBody] ServiceResource service)
        {
            if (!ModelState.IsValid) return BadRequest(service);

            try
            {
                var _service = _mapper.Map<ServiceResource, Medservices>(service);
                await _services.updateService(id,_service);
                return Ok("Xidmət yeniləndi.");
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _services.deleteService(id);
                return NoContent();
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetServices()
        {
            var services = await _services.getServices();
            return Ok(services);
        }
    }
}
