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
        //GetCarsByBrand(); //Sorunsuz

        //GetAllCar();      //Sorunsuz

        //BrandTest();      //Sorunsuz

        //Car mycar = new Car {CarId = 12, BrandId = 1, ColorId = 3, DailyPrice = 0, CarName = "qsadasd"};
        //AddCar(mycar);    //Sorunsuz

        GetCarDetail();

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
            Console.WriteLine(car.CarId + "***" + car.ModelYear + "***" + car.DailyPrice + "***" + car.CarName);
        }
    }
    private static void BrandTest()
    {
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        foreach (var brand in brandManager.GetAll().Data)
        {
            Console.WriteLine(brand.BrandId + " " + brand.BrandName);
        }
    }
    private static void GetCarsByBrand(int brandId)
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GellAllByBrandId(brandId);
        foreach (var car in result.Data)
        {
            Console.WriteLine(car.CarId + "***" + car.BrandId + "***" + car.CarName);
        }
    }
    private static void GetCarDetail()
    {
        CarManager carManager = new CarManager(new EfCarDal());
        var result = carManager.GetCarDetails();

        if (result.Success == true)
        {
            foreach (var car in result.Data)
            {
                Console.WriteLine(car.CarName + " *** " + car.ColorName + " *** " + car.BrandName + " *** " + car.DailyPrice);
            }
        }
        else
        {
            Console.WriteLine(result.Message);
        }

    }
    
}