using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    //NuGet
    public class EfCarDal : EfEntityRepositoryBase<Car, AracSatisContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            //üç tablo join işlemi
            using (AracSatisContext context = new AracSatisContext())
            {
                var result = from c in context.Cars
                             join col in context.Colors
                             on c.CarId equals col.ColorId
                             join b in context.Brands
                             on c.CarId equals b.BrandId
               
                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = col.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return result.ToList();
            }
        }
    }
}
