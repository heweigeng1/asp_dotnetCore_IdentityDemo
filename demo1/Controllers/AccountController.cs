using EfData.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<User> _userManager { get; set; }
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Route("register")]
        public async Task<IdentityResult> Register()
        {
            var user = new User { Id = Guid.NewGuid(), PhoneNumber = "13333333333", UserName = "admin2", Email = "admin@163.com" };
            var result = await _userManager.CreateAsync(user, "123456_zZ");
            return result;
        }

    }
}
