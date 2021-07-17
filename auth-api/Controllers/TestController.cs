using Microsoft.AspNetCore.Mvc;
using auth_api.services;
using System;
using System.Linq;
using System.Threading.Tasks;
using auth_api.Entities;
using auth_api.Repositories;

namespace auth_api.Controllers
{
    public class TestController : ControllerBase
    {
        private readonly UserRepository _userRepo;

        public TestController(UserRepository userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpGet]
        [Route("/v1")]
        public void test () {
            var hash = PasswordService.generatePasswordHash("password123");
            Console.WriteLine(hash);
            Console.WriteLine(PasswordService.checkPass("password123", hash));
            Console.WriteLine(PasswordService.checkPass("passwodr123", hash));
        }

        [HttpPost]
        [Route("/v1/test")]
        public IActionResult AddUser ([FromBody]UserEntity user)
        {
            Console.WriteLine(user);
            _userRepo.AddUser(user);
            _userRepo.Save();
            return Ok(user);
        }
    }
}