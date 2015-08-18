using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using CLabanowski.Models.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CLabanowski.Infrastructure
{
    public class IdentityUserClaimsIdentityFactory : ClaimsIdentityFactory<IdentityUser>
    {
        public async Task<ClaimsIdentity> CreateAsync(
            UserManager<IdentityUser> manager,
            IdentityUser user,
            string authenticationType)
        {
            var identity = await base.CreateAsync(manager, user, authenticationType);
            //identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));

            return identity;
        }
    }
}