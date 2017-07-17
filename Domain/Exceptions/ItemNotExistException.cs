using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ItemNotExistException : Exception
    {
        public ItemNotExistException(string message, Exception innerException) : base(message, innerException) { }
        public ItemNotExistException(string message) : base(message) { }
    }
}
