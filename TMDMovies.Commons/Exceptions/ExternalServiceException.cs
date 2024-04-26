using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMDMovies.Commons.Exceptions
{
    internal class ExternalServiceException : Exception
    {
        public ExternalServiceException(string? message) : base(message)
        {
        }

        public ExternalServiceException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
