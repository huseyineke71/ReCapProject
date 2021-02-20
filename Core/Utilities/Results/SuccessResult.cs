using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }
        //Tek parametre alanı success message vermek istemediğimiz tru olanı
        public SuccessResult() : base(true)
        {

        }

    }
}
