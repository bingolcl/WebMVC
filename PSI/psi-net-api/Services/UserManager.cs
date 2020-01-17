using Microsoft.EntityFrameworkCore;
using psi_net_api.Models;
using psi_net_api.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace psi_net_api.Services
{
    public class UserManager : IUserManager
    {
        PSIContext _psiContext { get; set; }

        public UserManager(PSIContext context)
        {
            _psiContext = context;
        }

        public List<User> GetAll()
        {
            var users = _psiContext.User.
                        Include(u => u.UserRoles).
                        ThenInclude(ur => ur.Role).
                        ToList();
            return users;
        }

        public User Find(string email)
        {
            var user = this.GetAll().Find(u => u.Email == email);
            return user;
        }

        public List<Role> GetRoles(User user)
        {
            var roles = user.UserRoles.Select(ur => ur.Role).ToList();
            return roles;
        }

    }
}
