using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api.Controllers 
{
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("v1/")]
        public string test () 
        {
            return "test";
        }
    }
}