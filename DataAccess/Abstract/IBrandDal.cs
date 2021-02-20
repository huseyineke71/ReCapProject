using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
   public interface IBrandDal:IEntityRepository<Brand>
    {
        //IEntityRepository yaptığımız için bunlara gerek kalmadı

        /*  List<Brand> GetAll();
          void Add(Brand brand);
          void Update(Brand brand);
          void Delete(Brand brand); */

    }
}
