using System;
using System.Collections.Generic;
using System.Text;

namespace Lab10.domain.validator
{
    class ValidateJucatorActiv : IValidator<JucatorActiv>
    {
        public string error;
        public void validate(JucatorActiv jucator)
        {
            error = "";
            if (jucator.tip != "Rezerva" && jucator.tip != "Participant")
                error += "Tipul juactorului poate fi doar Rezerva sau Participant";

            if (error != "")
            {
                throw new ValidationException(error);
            }
        }
    }
}
