using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SingletonPattern_NetCoreExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        [HttpGet("X")]
        public IActionResult X()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService.Count);
        }

        [HttpGet("Y")]
        public IActionResult Y()
        {
            DatabaseService databaseService = DatabaseService.GetInstance;
            databaseService.Connection();
            databaseService.Disconnect();
            return Ok(databaseService.Count);
        }
    }
}
