using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        //injection yaptık
        //sağdaki ampulden Generate constracture yaparak injection yaptık aşapıya oluşturdu(***UNUTMA Generate ÖNEMLİ***)
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine(car.Description + " başarı ile eklendi");
            }
            else
            {
                Console.WriteLine("günlük fiyatınız 0 dan büyük olmalıdır sisteme girilen deger : {car.DailyPrice}");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Description + "başarı ile silindi");
        }

        public List<Car> GetAll()
       {
            //iş kodları
            // yetkisi varmı ? 
            //kurallardan geçtimi
           return _carDal.GetAll();
       } 

       

         public List<Car> GetAllByBrand(int brandId)
         {

            return _carDal.GetAll(b=>b.BrandId == brandId);
         } 

         public List<Car> GetByModelYear(string year)
         {
             return _carDal.GetAll(m => m.ModelYear.Contains(year) == true);
         } 

         public List<Car> GetByPrice(decimal min, decimal max)
         {
             return _carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max);
         }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine(car.DailyPrice + " başarı ile güncellendi");
            }
            else
            {
                Console.WriteLine($"araba güncelleme aşamasında günlük fiyat hatalı girildi . O dan büyük giriniz girdiginiz deger {car.DailyPrice}");
            }
        }
    }

}



    
    
    
   

   


