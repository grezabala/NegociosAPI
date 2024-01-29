using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APINegocio.Controllers
{
    //[Route("api/[controller]")]
    [Route("/")]
    [Route("/index.html")]
    [ApiController]  
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        private void Homes()
        {
            string sms = "API Negocio";
            string stm = "Todo tipos de negocio";


        }

      

        //[Route("/")]
        //[Route("/index.html")]
        //public IActionResult Index()
        //{
        //    return new RedirectResult("~/swagger/index.html");
        //}

        [HttpGet]
        public async Task<IActionResult> Home()
        {
            var mensaje = Home();
            return Ok(await mensaje);
        }
    }
}
