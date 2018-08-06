using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EfData.Models
{
    public class TestUserStore : UserStore<User, Role, EfContext, Guid, UserClaim, UserRole, UserLogin, UserToken, RoleClaim>
    {
        public TestUserStore() : base(new EfContext(), null)
        {

        }
    }
}
