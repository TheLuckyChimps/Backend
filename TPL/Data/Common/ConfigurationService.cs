using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IConfiguration configuration;

        public ConfigurationService(
            IHttpContextAccessor httpContextAccessor,
            IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
        }
        public string GetJwt()
        {
            return httpContextAccessor.HttpContext.GetJsonWebToken();
            // return "da";
        }
        public string GetAccessToken()
        {
            return httpContextAccessor.HttpContext.GetAccessToken();
        }
    }
}
