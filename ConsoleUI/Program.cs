using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        //DTOs Data Transformation Object
        //Ioc

        static void Main(string[] args)
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}
            /* CarManager carManeger = new CarManager(new EfCarDal());
             foreach (var car in carManeger.GetAll())
             {
                 Console.WriteLine("Açıklama = " + car.Description + "---->" + "Aracın Fiyatı = " + car.DailyPrice);
             } */

            CarManager carManeger = new CarManager(new EfCarDal());
            foreach (var car in carManeger.GetCarDetails())
            {
                Console.WriteLine("Araç Adı = " + car.BrandName + "---->" + "Aracın Fiyatı = " + car.DailyPrice + "------>"+ "Aracın Rengi = "+ car.ColorName);
            }
            
        }
    }
}
