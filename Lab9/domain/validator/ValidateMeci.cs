using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidateMeci :IValidator<Meci>
    {
        public string error;
        public void validate(Meci meci)
        {
            error = "";
            if (meci.echipa1.id == 0 || meci.echipa2.id == 0)
                error += "Id-ul echipei nu poate fi 0.";
            if (meci.echipa1.nume == "" || meci.echipa2.nume == "")
                error += "Numele echipei nu poate fi nul.";
            if (error != "")
            {
                throw new ValidationException(error);
            }
        }
    }
}
