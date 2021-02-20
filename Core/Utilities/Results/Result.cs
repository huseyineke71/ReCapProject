using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //private bool v1;
        //private string v2;
        //Aşağıdaki iki Constructor da çalışması için this(Result class'ın kendisi demek Result demek) 
        //this demek Result'un tek paremetre alan Constructor una success yollarız
        public Result(bool success, string message):this(success)
        {
            //this.v1 = v1;
            //this.v2 = v2;
            Message = message;
            
        }
        //ikinci Constructor'dır Bu Overloding aşırı yükleme olur
        public Result (bool success)
        {
            Success = success;
        }
        //Get geter'lar set edilemez ama Constructor geter'lar set edilebilirler
        public bool Success { get; }

        public string Message { get; }
    }
}
