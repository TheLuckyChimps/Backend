using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common
{
    public interface IConfigurationService
    {
        string GetJwt();
        string GetAccessToken();
    }
}
