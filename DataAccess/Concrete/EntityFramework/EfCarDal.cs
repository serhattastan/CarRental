using Core.DataAccess.EntityFramework;
using DataAccess.Abstrarct;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarDatabaseContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarDatabaseContext context = new CarDatabaseContext())
            {
                var result = from c in context.Cars         // Products tablosu ile Categories tablosunu joinle
                             join b in context.Brands
                             on c.BrandId equals b.BrandId    //Şuna göre joinle ..CategoryId..
                             join x in context.Colors
                             on c.ColorId equals x.ColorId
                             select new CarDetailDto
                             {
                                 CarName = c.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = x.ColorName,
                                 DailyPrice = c.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
