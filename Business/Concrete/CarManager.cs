using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Results;
using Business.Constants;
using FluentValidation;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;

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

        public IResult Add(Car car)
        {
            //business codes
            //validation(Doğrulama)business ile validation kodları ayrı olmalıdır

            //var context = new ValidationContext<Car>(car);

            //CarValidator carValidator = new CarValidator();
            //var result = carValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //  ValidationTool.Validate(new ProductValidator(),product);
            ValidationTool.Validate(new CarValidator(),car );
            //if (car.DailyPrice > 0)
            //{
            //    _carDal.Add(car);
            //    Console.WriteLine(car.Description + " başarı ile eklendi");
            //}
            //else
            //{
            //    Console.WriteLine("günlük fiyatınız 0 dan büyük olmalıdır sisteme girilen deger : {car.DailyPrice}");
            //}
            
            //if (car.ModelYear.Length > 4)
            //{                                //magic string
            //    return new ErrorResult(Messages.CarNameInvalid);
            //}
            _carDal.Add(car);
            //Result altı kızardı burada Ampulden Generate Constructor in result yaparız ve
            //Result Class'ına  private bool v1; ve  private string v2; değerini atar
            //bu iki parametreli Constructor'dır
           // return new Result(true, "Ürün Eklendi");
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine(car.Description);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll()
       {
            //iş kodları
            // yetkisi varmı ? 
            //kurallardan geçtimi
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
           return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ProductsListed); 
       } 

       

         public IDataResult<List<Car>> GetAllByBrand(int brandId)
         {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b=>b.BrandId == brandId));
         }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<Car>> GetByModelYear(string year)
         {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(m => m.ModelYear.Contains(year) == true));
         } 

         public IDataResult<List<Car>> GetByPrice(decimal min, decimal max)
         {
             return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.DailyPrice >= min && p.DailyPrice <= max));
         }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IResult Update(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Update(car);
                Console.WriteLine(car.DailyPrice );
            }
            else
            {
                Console.WriteLine($"araba güncelleme aşamasında günlük fiyat hatalı girildi . O dan büyük giriniz girdiginiz deger {car.DailyPrice}");
            }
             return new SuccessResult(Messages.CarUpdated);
        }
    }

}



    
    
    
   

   


