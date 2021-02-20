using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<Car> GetAll();
        List<Car> GetAllByBrand(int brandId);
        List<Car> GetByPrice(decimal min, decimal max);
        List<Car> GetByModelYear(string year);
        List<CarDetailDto> GetCarDetails();


    }
}
