using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface ICarService
{
    List<Car> GetAllCars();
    Car GetCarById(int carId);  
    bool AddCar(Car car);
    bool UpdateCar(Car car);
    bool DeleteCar(int carId);
}