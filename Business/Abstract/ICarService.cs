using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        //burada GetAll'da Data döndürebilmek için(Data,mesaj,işlem sonucu döndürmek için) IDataResult yaptık ve bir IDataResult adında interface oluşturduk
        //yukarıda Add void metodunda sadece mesaj işlemleri için Result oluşturduk
        IDataResult<List<Car>> GetAll();
        IDataResult <Car> GetById(int carId);
        IDataResult<List<Car>> GetAllByBrand(int brandId);
        IDataResult<List<Car>> GetByPrice(decimal min, decimal max);
        IDataResult<List<Car>> GetByModelYear(string year);
        IDataResult<List<CarDetailDto>> GetCarDetails();


    }
}
