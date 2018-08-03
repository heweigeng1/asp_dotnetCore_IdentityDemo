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
        private  UserManager<User> _userManager { get; set; }
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            _userManager.CreateAsync(new User { });
            return "value";
        }

    }
}
