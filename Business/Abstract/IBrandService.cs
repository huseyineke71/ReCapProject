﻿using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand brand);
        IResult Delete(Brand barnd);
        IDataResult<List<Brand>> GetAll();
        IDataResult<Brand> GetById(int brandId);
        
    }
}
