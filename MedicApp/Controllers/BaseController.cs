using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MedicApp.Data.Entities.Admin;

namespace MedicApp.Controllers
{
    [Route("v{ver:apiVersion}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMapper _mapper => HttpContext.RequestServices.GetService<IMapper>();
        protected User _user => RouteData.Values["User"] as User;
    }
}
