
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //Core Katmanları diğer katmanları referans almaz
    //gereric constraint
    //class : referans tip
    //IEntity : IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    //new() : new'lenebilir olmalı
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //Expression(Delegate) ile GetAll Tek Metot yazdık Veriyi Filtreleyerek alacağız(GetAllByBrand,GetByPrice,GetByModelYear gibi metotları tek Metota topladık) 
        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        //Tek Data getirmek için yazdık Veriyi filtrelemeden Tek datada alacağız(Örnek Bankacılık sisteminde bir Kredinin Detayını getirmek için)       
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        // List<T> GetAllByBrand(int brandId);
        // List<T> GetByPrice(decimal min, decimal max);
        // List<T> GetByModelYear(string year);
        //Buradaki List<T> GetAll() InMemoryCarDal çalışması için olması gerek(açtığımızda program.cs de new InMemoryCarDal değiştiririz)
        //Bunu açarsak InMemoryCarDal çalışır
        //List<T> GetAll();
    }
}
