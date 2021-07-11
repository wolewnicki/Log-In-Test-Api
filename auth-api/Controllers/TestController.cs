using Microsoft.AspNetCore.Mvc;
using auth_api.services;
using System;
using auth_api.Data;
using System.Linq;
using System.Threading.Tasks;

namespace auth_api.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly HashApi _hashService;
        private readonly DataContext _dataContext;

        public TestController(HashApi hashService, DataContext dataContext)
        {
            _hashService = hashService;
            _dataContext = dataContext;
        }


        [HttpGet]
        [Route("/v1")]
        public void test () {
            var hash = _hashService.generatePassword("password123");
            Console.WriteLine(hash);
            Console.WriteLine(_hashService.checkPass("password123", hash));
            Console.WriteLine(_hashService.checkPass("passwodr123", hash));
        }

        [HttpGet]
        [Route("/v1/test")]
        public IActionResult query ()
        {
            var db = _dataContext;
            var q = db.users
            .Where(u => u.name == "test")
            .ToList();

            return Ok(q);
        }
    }
}