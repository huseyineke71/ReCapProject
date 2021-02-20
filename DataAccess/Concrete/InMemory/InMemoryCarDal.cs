using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal : ICarDal
    {
        //_cars Global değişkendir(Name Convention)

        List<Car> _cars;

        //construction oluşturduk
        public InMemoryCarDal()
        {
            //Bu sanal bir veridir veri tabanından geliyormuş gibi(SQL,Oracle,MySql,MongoDb...)
            //Aşaıdaki verilerin hepsinin Referans tipleri ayrıdır Heap teki yerleri farklıdır
            _cars = new List<Car> {
                new Car{ CarId=1, BrandId=1, ColorId=1, ModelYear="2015", DailyPrice=80000, Description="Temiz bir Araç"},
                new Car{ CarId=2, BrandId=2, ColorId=2, ModelYear="2018", DailyPrice=100000, Description="Orta Segment bir Araç"},
                new Car{ CarId=3, BrandId=3, ColorId=3, ModelYear="2017", DailyPrice=90000, Description="Orta Segment bir Araç"},
                new Car{ CarId=4, BrandId=1, ColorId=2, ModelYear="2013", DailyPrice=60000, Description="İyi bir Araç"},
                new Car{ CarId=5, BrandId=2, ColorId=4, ModelYear="2021", DailyPrice=120000, Description="Lüks bir Araç"}
            };
        }
        //Yukarıda Tanımladığımız veri Tabanına veri ekledik 
        public void Add(Car car)
        {
            car.CarId = _cars.Last().CarId + 1;
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
           /* Car carToDelete = null;

            foreach (var c in _cars)
            {
                if (car.CarId == c.CarId)
                {
                    carToDelete = c;
                }
            } */
            //LINQ Language Integrated Query tekniği ile böyle yazılır
            //SingleOrDefault(metot'tur) tek eleman için ürünleri dolaşır foreac yapar
            //c=> Lambda işaretidir c takma addır tek tek dolaşır
                                //foreach yap   c takma isim ver kuralı buraya yaz
           Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == c.CarId);

            //Referans Tipi bu şekilde sadece bunu yazmakla silmez pimary key bulup eşleşen Id silmeliyiz yukarıdaki kodu yazmalıyız
            _cars.Remove(carToDelete);
        }
        public void Update(Car car)
        {
            //Gönderdiğim ürün Id'sine sahip olan listedeki ürünü bul
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }
        //Burada Veri Tabanını olduğu gibi döndürüyoruz.
        public List<Car> GetAll()
        {
           
            return _cars;
        }
       /* public List<Car> GetByPrice()
        {
            return _cars.OrderByDescending(c => c.DailyPrice).ToList();
        } */
       /* public List<Car> GetByModelYear()
        {
            return _cars.OrderByDescending(c => c.ModelYear).ToList();
        } */
        public List<Car> GetAllByBrand(int brandId)
        {
            return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetByPrice(decimal min, decimal max)
        {
            return _cars.OrderByDescending(c => c.DailyPrice).ToList();
        }

        public List<Car> GetByModelYear(string year)
        {
            return _cars.OrderByDescending(c => c.ModelYear).ToList();
        }
        //EfCarDal daki verilerin çalışması için bunların burada olması gerek otomatik implemente ediyor
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        } 

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
