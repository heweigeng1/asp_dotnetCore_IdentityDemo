using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfData.Models
{
    public class UserLogin : IdentityUserLogin<Guid>
    {
        public Guid Id { get; set; }
    }
}
