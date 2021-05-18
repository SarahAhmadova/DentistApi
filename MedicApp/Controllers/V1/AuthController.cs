using MedicApp.Data.Entities.Admin;
using MedicApp.Infrastructure.Exceptions;
using MedicApp.Resoruce.Auth;
using MedicApp.Resource.Auth;
using MedicApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicApp.Controllers.V1
{
    [ApiVersion("1.0")]
    public class AuthController : BaseController
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody]LoginResource resource)
        {
     


            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var user = await _userService.Login(resource.Email, resource.Password);

                var userResource = _mapper.Map<User, UserResource>(user);
                return Ok(userResource);
            }
            catch (HttpException ex)
            {

                return StatusCode(ex.StatusCode, ex.ResponseObj);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterResource resource)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var userResource = _mapper.Map<RegisterResource,User>(resource);
                var user = await _userService.Register(userResource);
                var userr = _mapper.Map<User, RegisterResource>(user);

                return Ok(userr);
            }
            catch (HttpException ex)
            {
                return StatusCode(ex.StatusCode, ex.ResponseObj);
            }
        }
    }
}
