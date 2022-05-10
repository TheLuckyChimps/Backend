using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common.Exceptions
{
    public class UserConfigurationException : Exception
    {
        private readonly string message = string.Empty;

        public UserConfigurationException()
        {
        }

        public UserConfigurationException(string message)
            : base(message)
        {
            this.message = message;
        }

        public UserConfigurationException(string message, Exception innerException)
            : base(message, innerException)
        {
            this.message = message;
        }

        public sealed override string Message => $"User configuration exception: { message }";
    }
}
