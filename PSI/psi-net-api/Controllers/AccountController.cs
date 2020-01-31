using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSI.Data;
using PSI.Service.interfaces;

namespace psi_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IActiveDirectoryService _activeDirectoryService { get; set; }
        IUserService _userService { get; set; }

        public AccountController(IActiveDirectoryService activeDirectoryService,
                                 IUserService userService)
        {
            _activeDirectoryService = activeDirectoryService;
            _userService = userService;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string email, string password)
        {
            string username = email.Trim().ToLower();
            if (_activeDirectoryService.Authenticate(username, password))
            {
                return Ok(new { success = true, message = "Successful Login." });
            }
            return Ok(new { success = false, message = "Invalid Login. Please try again..." });            
        }

        [HttpGet]
        [Route("GetPSIUsers")]
        public IEnumerable<User> GetPSIUsers()
        {
            var users = _userService.GetAll();
            return users;
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public IEnumerable<Role> GetUserRoles(string email)
        {
            var user = _userService.Find(email);
            var roles = _userService.GetRoles(user);
            return roles;
        }

    }
}