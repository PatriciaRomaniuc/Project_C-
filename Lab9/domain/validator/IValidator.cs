using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    interface IValidator<E>
    {
        void validate(E elem);
    }
}
