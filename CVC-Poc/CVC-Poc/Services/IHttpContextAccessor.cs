using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Services
{
    public interface IHttpContextAccessor
    {
        HttpContext HttpContext { get; }
    }
}
