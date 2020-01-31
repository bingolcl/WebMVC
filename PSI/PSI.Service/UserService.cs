using Microsoft.EntityFrameworkCore;
using PSI.Data;
using PSI.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSI.Service
{
    public class UserService : IUserService
    {
        PSIDevContext _psiContext { get; set; }

        public UserService(PSIDevContext context)
        {
            _psiContext = context;
        }

        public List<User> GetAll()
        {
            var users = _psiContext.User.
                        Include(u => u.UserInRole).
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
            var roles = user.UserInRole.Select(ur => ur.Role).ToList();
            return roles;
        }

    }
}
