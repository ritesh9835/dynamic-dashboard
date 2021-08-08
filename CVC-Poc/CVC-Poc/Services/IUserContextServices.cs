using CVC_Poc.Models.Constant;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CVC_Poc.Services
{
    public interface IUserContextServices
    {
        UserSession GetUserContext();
        bool IsUserAuthenticated();
    }

    public class UserContextService : IUserContextServices
    {
        private readonly IHttpContextAccessor contextAccessor;
        private UserSession _userContext;
        public UserContextService(IHttpContextAccessor accessor)
        {
            contextAccessor = accessor;
        }

        private HttpContext Context
        {
            get
            {
                return contextAccessor.HttpContext;
            }
        }

        public UserSession GetUserContext()
        {
            if (_userContext == null && IsUserAuthenticated())
            {
                var user = Context?.Session.GetString(CVCConstants.SessionName);
                var userSession = JsonConvert.DeserializeObject<UserSession>(user);
                _userContext = new UserSession()
                {
                    Id = userSession != null ? userSession.Id : 0,
                    Name = userSession?.Name,
                    Roles = userSession != null ? userSession.Roles : 0
                };
            }
            return _userContext;
        }

        public bool IsUserAuthenticated()
        {
            var user = Context?.Session.GetString(CVCConstants.SessionName);
            return string.IsNullOrEmpty(user);
        }
    }

}
