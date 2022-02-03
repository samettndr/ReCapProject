using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context=new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join cl in context.Colors on cr.ColorId equals cl.ColorId
                             join br in context.Brands on cr.BrandId equals br.BrandId
                             select new CarDetailDto
                             {
                                 CarName = cr.CarName,
                                 BrandName = br.BrandName,
                                 ColorName = cl.ColorName
                             };
                return result.ToList(); 
            }
        }
    }
}
