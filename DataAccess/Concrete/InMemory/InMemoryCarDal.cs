using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {

        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car {CarId=1,BrandId=1,ColorId=1,ModelYear=1997,DailyPrice=50000,Description="Hızlı Araba"},
            new Car {CarId=2,BrandId=2,ColorId=9,ModelYear=1997,DailyPrice=150000,Description="Konforlu Araba"},
            new Car {CarId=3,BrandId=3,ColorId=3,ModelYear=1997,DailyPrice=250000,Description="Güzel Araba" },
            new Car {CarId=4,BrandId=4,ColorId=6,ModelYear=1997,DailyPrice=100000,Description="Yavaş Araba" },
            new Car {CarId=5,BrandId=5,ColorId=8,ModelYear=1997,DailyPrice=300000,Description="Aile Arabası" } };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {
            return _cars.Where(c => c.CarId == Id).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;

        }
    }
}
