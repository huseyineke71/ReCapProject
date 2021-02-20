using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //Code Refactoring 
    public interface ICarDal : IEntityRepository<Car>
    {
        //ICarDal ait Join yazdık
        List<CarDetailDto> GetCarDetails();

        //Burasını IEntityRepository taşıdık
        
        /*List<Car> GetAll();
         void Add(Car car);
         void Update(Car car);
         void Delete(Car car); 
         List<Car> GetAllByBrand(int brandId);
         List<Car> GetByPrice(decimal min, decimal max);
         List<Car> GetByModelYear(string year); */
        
    }
}
