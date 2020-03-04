using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidationException : Exception
    {
        public ValidationException(String message) : base(message){}
        public ValidationException() : base() { }
    
    }
}
