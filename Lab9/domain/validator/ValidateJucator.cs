using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidateJucator : IValidator<Jucator>
    {
        public string error;
        public void validate(Jucator jucator)
        {
            error = "";
            if (jucator.nume == "")
                error += "Numele nu poate fi nul";
            if(jucator.scoala=="")
                error += "Scoala nu poate fi nula";
            if (jucator.echipa.nume=="")
                error += "Numele echipei nu poate fi nul";

            if (error != "")
            {
                throw new ValidationException(error);
            }
        }
    }
}
