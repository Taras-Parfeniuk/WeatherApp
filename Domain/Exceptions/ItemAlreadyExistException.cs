using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ItemAlreadyExistException : Exception
    {
        public ItemAlreadyExistException(string message, Exception innerException) : base(message, innerException) { }
        public ItemAlreadyExistException(string message) : base(message) { }
    }
}
