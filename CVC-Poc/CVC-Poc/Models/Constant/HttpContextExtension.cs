using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Models.Constant
{
    public static class HttpContextExtension
    {
        public static UserManager<TUser> GetUserManager<TUser>(this HttpContext context) where TUser : class
        {
            return context.RequestServices.GetRequiredService<UserManager<TUser>>();
        }
    }
}
