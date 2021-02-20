using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //Temel voidler için başlangıç tek bir işlem için
    //doğru ve yanlış mesajı vermek için değer döndürmeyen için işlem sonucu ve mesaj için
   
  public  interface IResult
    {
        // public bool Success => throw new NotImplementedException();
        // public string Message => throw new NotImplementedException();
        bool Success { get; }
        string Message { get; }
    }
}
