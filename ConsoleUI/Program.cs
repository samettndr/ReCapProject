using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            //ColorTest();
            //BrandTest();
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();
            if (result.Success)
            {

                foreach (var brand in brandManager.GetAll().Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
                Console.WriteLine();
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();
            if (result.Success)
            {

                foreach (var color in colorManager.GetAll().Data)
                {
                    Console.WriteLine(color.ColorName);
                }
                Console.WriteLine();
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }


        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Car car1 = new Car { CarId = 5,CarName="Maserati", BrandId = 5, ColorId = 6, ModelYear = 2021, DailyPrice = 1000000, Description = "ARABA" };

            var result = carManager.Update(car1);
            if (result.Success)
            {
                Console.WriteLine(car1.CarName);
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
