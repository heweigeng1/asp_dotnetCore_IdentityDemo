using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfData.Models
{
    public class UserToken : IdentityUserToken<Guid>
    {
        public Guid Id { get; set; }
    }
}
