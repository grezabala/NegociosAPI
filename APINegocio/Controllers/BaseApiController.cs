using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {

    }

    public interface IController<T>
    {
        Task<IActionResult> Get();
        Task<IActionResult> Post(T model);
        Task<IActionResult> Get(int Id);
        Task<IActionResult> Get(T model);
        Task<IActionResult> Delete(int Id);
        Task<IActionResult> Put(int Id, T model);

    }
}
