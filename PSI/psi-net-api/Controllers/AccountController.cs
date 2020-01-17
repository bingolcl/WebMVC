using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using psi_net_api.Models;
using psi_net_api.Services.interfaces;

namespace psi_net_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IActiveDirectoryService _activeDirectoryService { get; set; }
        IUserManager _userManager { get; set; }

        public AccountController(IActiveDirectoryService activeDirectoryService,
                                 IUserManager userManager)
        {
            _activeDirectoryService = activeDirectoryService;
            _userManager = userManager;
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
            var users = _userManager.GetAll();
            return users;
        }

        [HttpGet]
        [Route("GetUserRoles")]
        public IEnumerable<Role> GetUserRoles(string email)
        {
            var user = _userManager.Find(email);
            var roles = _userManager.GetRoles(user);
            return roles;
        }

    }
}