using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using Core;
using Core.Data;
using Data;

namespace Service
{
    public class UserService : EntityService<User>, IUserService
    {
        IDbContext _context;

        public UserService(IDbContext context)
            : base(context)
        {
            _context = context;
        }

        public User GetUserByADUserName(string userName)
        {
            return this.Entities.FirstOrDefault(u => u.AdUsername == userName);
        }
    }
}