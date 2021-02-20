using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        //Tek parametre alanı success message vermek istemediğimiz tru olanı
        public ErrorResult() : base(false)
        {

        }
    }
}
