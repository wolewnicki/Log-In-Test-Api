using Microsoft.AspNetCore.Mvc;
using auth_api.services;
using System;

namespace auth_api.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly HashApi _hashService;

        public TestController(HashApi hashService)
        {
            _hashService = hashService;
        }


        [HttpGet]
        [Route("/v1")]
        public void test () {
            var hash = _hashService.generatePassword("password123");
            Console.WriteLine(hash);
            Console.WriteLine(_hashService.checkPass("password123", hash));
            Console.WriteLine(_hashService.checkPass("passwodr123", hash));
        }
    }
}