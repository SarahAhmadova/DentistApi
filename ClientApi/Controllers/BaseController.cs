using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ClientApi.Controllers
{
    [Route("v{ver:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMapper _mapper => HttpContext.RequestServices.GetService<IMapper>();
        
    }
}
