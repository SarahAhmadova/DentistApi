using MedicApp.Data.Entities;
using MedicApp.Infrastructure.Exceptions;
using MedicApp.Infrastructure.Filter;
using MedicApp.Resource.Specialities;
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
    public class SpecialitiesController : BaseController
    {
        private readonly ISpecialityService _specService;

        public SpecialitiesController(ISpecialityService specialityService)
        {
            _specService = specialityService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> addSpeciality([FromBody] Speciality spec)
        {
            if (!ModelState.IsValid) return BadRequest(spec);

            try
            {
                var _spec = await _specService.addSpeciality(spec);
                return Ok(_spec);
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }

        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> editSpeciality([FromRoute] int id, [FromBody] EditSpecResource spec)
        {
            if (!ModelState.IsValid) return BadRequest(spec);

            try
            {
                var _spec = _mapper.Map<EditSpecResource, Speciality>(spec);
                await _specService.updateSpeciality(id, _spec);

                return Ok("Updated");
            }
            catch (HttpException e)
            {
                return StatusCode(e.StatusCode, e.ResponseObj);
            }

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> deleteSpec([FromRoute] int id)
        {
            try
            {
                await _specService.deleteSpeciality(id);
                return NoContent();
            }
            catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ResponseObj);
            }
        }


        [HttpGet]
        [Route("")]

        public async Task<IActionResult> GetSpecList()
        {
            var specList = await _specService.getSpecList();

            return Ok(specList);
        }


        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetSpec([FromRoute] int id)
        {
            var spec = await _specService.getSpeciality(id);

            return Ok(spec);
        }


    }
}