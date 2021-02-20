using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //burada GetAll'da Data döndürebilmek için(Data,mesaj,işlem sonucu içinde) IDataResult yaptık<T>:IResult'da içeriyor aynı zamanda IResult
    public interface IDataResult<T>:IResult
    {
        //burada aynı zamanda generic(T) ile data döndürüyoruz
        T Data { get; }

    }
}
