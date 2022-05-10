using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common.Exceptions;

namespace TPL.Data.Common
{
    public static class HttpContextExtensions
    {
        public static string GetJsonWebToken(this HttpContext httpContext)
        {
            //httpContext.EnsureUserIsAuthenticated();
            //httpContext.EnsureAuthorizationHeaderIsPresent();

            string bearerToken = httpContext.Request.Headers["Authorization"].ToString();

            return bearerToken.Replace("Bearer ", string.Empty);
        }
        public static string GetAccessToken(this HttpContext httpContext)
        {
            httpContext.EnsureUserIsAuthenticated();
            httpContext.EnsureAuthorizationHeaderIsPresent();

            string accesToken = httpContext.Request.Headers["Access"].ToString();

            //return bearerToken.Replace("Bearer ", string.Empty);
            return accesToken;
        }

        private static void EnsureUserIsAuthenticated(this HttpContext httpContext)
        {
            bool isAuthenticated = httpContext?.User?.Identity?.IsAuthenticated ?? false;
            if (!isAuthenticated)
            {
                throw new UserConfigurationException(
                    message: "User should be authenticated before accessing httpContext values.");
            }
        }

        private static void EnsureAuthorizationHeaderIsPresent(this HttpContext httpContext)
        {
            bool hasHeader = httpContext?.Request?.Headers?.ContainsKey("Authorization") ?? false;
            if (!hasHeader)
            {
                throw new UserConfigurationException(
                    message: "Authorization header should be present before accessing header values.");
            }
        }
    }
}
