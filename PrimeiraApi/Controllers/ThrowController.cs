using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    public class ThrowController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()=>{

    }
}
