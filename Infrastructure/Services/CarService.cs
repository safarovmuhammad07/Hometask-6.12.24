using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;



namespace Infrastructure.Services
{
    public class CarService : ICarService
    {
        public const string connectionString = "Server=127.0.0.1;Port=5432;Database=StudentDB;User Id=postgres;Password=1234;";

        public List<Car> GetAllCars()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sqlcommand = "Select * from Cars";
                List<Car> cars = connection.Query<Car>(sqlcommand).ToList();
                return cars;
            }
        }

        public Car GetCarById(int carId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sql = "Select * from Cars where CarId=@CarId";
                Car car = connection.QuerySingle<Car>(sql, new { CarId = carId });
                return car;
            }
        }

        public bool AddCar(Car car)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sql = "Insert into Cars(Brand, Model, Color, Year) values (@Brand, @Model, @Color, @Year)";
                var result = connection.Execute(sql, car);
                return result > 0;
            }
        }

        public bool UpdateCar(Car car)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sql = "Update Cars set Brand=@Brand, Model=@Model, Color=@Color, Year=@Year where CarId=@CarId";
                var result = connection.Execute(sql, car);
                return result > 0;
            }
        }

        public bool DeleteCar(int CarId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                var sql = "Delete from Cars where CarId=@CarId";
                var result = connection.Execute(sql, new { CarId });
                return result > 0;
            }
        }
    }
}
