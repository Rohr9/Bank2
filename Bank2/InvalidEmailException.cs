using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
