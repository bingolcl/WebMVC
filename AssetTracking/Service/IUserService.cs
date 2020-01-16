using System;
using System.Collections.Generic;
using Core;
using Data;

namespace Service
{
    public interface IUserService : IEntityService<User>
    {
        User GetUserByADUserName(string userName);
    }
}