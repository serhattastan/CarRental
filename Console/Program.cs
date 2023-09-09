using Business.Concrete;
using DataAccess.Abstrarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUIUI;
//SOLID
//O - Open Closed Principle
//DTOs == Data Transform Object
class Program
{
    static void Main(string[] args)
    {
        GetAllCar();
    }
    private static void AddCar(Car car)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        carManager.Add(car);
        
    }
    private static void GetAllCar()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetAll();
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarId + "***" + car.ModelYear + "***" + car.DailyPrice + "***" + car.Description);
        }
    }
    //List<Car> cars;
    //cars = new List<Car>
    //{
    //    new Car{CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2023, DailyPrice = 5600, Description = "Porsche Cayenne"},
    //    new Car{CarId = 2, BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 5000, Description = "Porsche Taycan"},
    //    new Car{CarId = 3, BrandId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 1800, Description = "Ford Focus"},
    //    new Car{CarId = 4, BrandId = 2, ColorId = 3, ModelYear = 2023, DailyPrice = 4800, Description = "Ford Mustang"},
    //    new Car{CarId = 5, BrandId = 3, ColorId = 1, ModelYear = 2015, DailyPrice = 1000, Description = "Toyota Corolla"}
    //};
    //foreach (var car in cars)
    //{
    //    AddCar(car);
    //}
}