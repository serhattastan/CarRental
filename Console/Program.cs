using Business.Concrete;
using DataAccess.Abstrarct;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.VisualBasic;

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

        //GetCarDetail();

        Rental newRental = new Rental { Id = 6, CarId = 3, CustomerId = 2, RentDate = DateTime.Now, ReturnDate = null };
        AddRent(newRental);

        //GetAllRental();

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
    private static void AddRent(Rental rental)
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        rentalManager.Add(rental);
    }
    private static void GetAllRental()
    {
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        var result = rentalManager.GetAll();
        foreach (var rental in result.Data)
        {
            Console.WriteLine( rental.Id + rental.CarId + rental.CustomerId);
        }
    }
    
}