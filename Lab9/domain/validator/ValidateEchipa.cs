using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidateEchipa: IValidator<Echipa>
    {
        public string error;
        public void validate(Echipa echipa)
        {
            error = "";
            if (echipa.nume == "")
                error += "Numele echipei nu poate fi nul.";
            if (error != "")
            {
                throw new ValidationException(error);
            }
        }
    }
}
