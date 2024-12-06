

using Infrastructure.Models;
using Infrastructure.Services;

CarService carService = new CarService();

EmployeeService employeeService = new EmployeeService();

Car car = new Car
{
    Brand = "Audi",
    Model = "A6",
    Color = "Black",
    Year = 2020
};

//Console.WriteLine(carService.AddCar(car));
//foreach (var x in carService.GetAllCars())
//{
  //  Console.WriteLine($"{x.CarId}, {x.Model}, {x.Color}, {x.Year}");
//}
//var carar =carService.GetCarById(int.Parse(Console.ReadLine()));
//Console.WriteLine(carar.Model);

