<<<<<<< HEAD
﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManeger = new CarManager(new EfCarDal());
            foreach (var car in carManeger.GetAll())
            {
                Console.WriteLine("Açıklama = " + car.Description + "---->" + "Aracın Fiyatı = " + car.DailyPrice);
            }

            
        }
    }
}
=======
﻿using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFrameWork;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManeger = new CarManager(new EfCarDal());
            foreach (var car in carManeger.GetAll())
            {
                Console.WriteLine("Açıklama = " + car.Description + "---->" + "Aracın Fiyatı = " + car.DailyPrice);
            }

            
        }
    }
}
>>>>>>> 19a8ddb64c894566652172e5f2de5143e25f38ba
