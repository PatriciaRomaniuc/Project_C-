using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidateElev:IValidator<Elev>
    {
        public string error;
        public void validate(Elev elev)
        {
            error = "";
            if (elev.nume == "")
                error += "Numele nu poate fi nul.";
            if (elev.scoala == "")
                error += "Scoala nu poate fi nula.";
            if (error != "")
            {
                throw new ValidationException(error);
            }
        }
    }
}
