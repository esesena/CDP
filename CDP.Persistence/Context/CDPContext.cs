using CDP.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDP.Persistence.Context
{
    public class CDPContext : IdentityDbContext<User, Role, int,
                                                        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
    }
}
