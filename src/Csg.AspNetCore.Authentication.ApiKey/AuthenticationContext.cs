using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Csg.AspNetCore.Authentication.ApiKey
{
    public class AuthenticatedEventContext : Microsoft.AspNetCore.Authentication.HandleRequestContext<ApiKeyOptions>
    {
        public AuthenticatedEventContext(HttpContext context, AuthenticationScheme scheme, ApiKeyOptions options, string clientID, System.Security.Claims.ClaimsIdentity identity) : base(context, scheme, options)
        {
            this.ClientID = clientID;
            this.Identity = identity;
        }

        public string ClientID { get; protected set; }

        public System.Security.Claims.ClaimsIdentity Identity { get; protected set; }

        public void Success(AuthenticationTicket ticket)
        {
            this.Result = HandleRequestResult.Success(ticket);
        }
        
        public void Fail(Exception exception)
        {
            this.Result = HandleRequestResult.Fail(exception);
        }

        public void Fail(string failureMesage)
        {
            this.Result = HandleRequestResult.Fail(failureMesage);
        }
    }
}
