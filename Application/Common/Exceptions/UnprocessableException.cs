using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Exceptions
{
    public class UnprocessableException : Exception
    {
        public UnprocessableException(string message) : base(message) { }
    }
}
