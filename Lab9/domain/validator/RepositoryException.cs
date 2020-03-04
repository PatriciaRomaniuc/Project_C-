using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class RepositoryException :ApplicationException
    {
        public RepositoryException() : base() { }
        public RepositoryException(String s) : base(s) { }
    }
}
