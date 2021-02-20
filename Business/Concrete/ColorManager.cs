using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class ColorManager : IColorService
    { //_colorDal üzerine tıklayıp uyarı Ampulünden Generate Constructor yaparız aşağısı çıkar
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine(color.ColorName);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(color.ColorName);
            return new SuccessResult(Messages.ColorDeleted);
        }
        public IResult Update(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine(color.ColorName);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IDataResult<List<Color>> GetAll()
        {
           
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        
    }
}
