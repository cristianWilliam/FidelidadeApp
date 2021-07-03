using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FidelidadeApp.Controllers.Abstractions
{
    [Authorize]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
    }
}
