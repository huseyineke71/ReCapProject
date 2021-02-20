using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, AracSatisContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (AracSatisContext context = new AracSatisContext())
            {
                var result = from r in context.Rentals
                             join cus in context.Customers
                             on r.RentalId equals cus.CustomerId

                             join u in context.Users
                             on r.RentalId equals u.UserId

                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 ContactName =cus.ContactName,
                                 CompanyName = cus.CompanyName,
                                 Email = u.Email,
                                 City = cus.City,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
