using Dapper;
using Infrastructure.Interfaces;
using Infrastructure.Models;
using Npgsql;

namespace Infrastructure.Services;

public class EmployeeService:IEmployeeService
{
    public const string connectionString= "Server=127.0.0.1;Port=5432;Database=EmployeeDB;User Id=postgres;Password=1234;";

    public List<Employee> getAllEmployees()
    {
        using (var connection= new NpgsqlConnection(connectionString) )
        {
            var sql = "select * from employees";
            List<Employee> employees = connection.Query<Employee>(sql).ToList();
            return employees;
        }
    }

    public Employee GetEmployeeById(int id)
    {
        using (var connection= new NpgsqlConnection(connectionString))
        {
            var sql = "select * from employees where id = @id";
            Employee employee = connection.QuerySingle<Employee>(sql, new { Id=id  });
            return employee;
        }
    }

    public bool AddEmployee(Employee employee)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "Insert into Employee(Name,Position,Department,Adress,Email,Phone) values (@Name,@Position,@Department,@Adress,@Email,@Phone) )";
            var result = connection.Execute(sql, employee);
            return result > 0;
        }
    }

    public bool UpdateEmployee(Employee employee)
    {
        using (var connection= new NpgsqlConnection(connectionString))
        {
            var sql =
                "Update Employe set Name=@Name, Position=@position, Department=@department, Adress=@adress, Email=@email, Phone=@phone";
            var result = connection.Execute(sql, employee);
            return result > 0;
            
        }
    }

    public bool DeleteEmployee(int id)
    {
        using (var connection = new NpgsqlConnection(connectionString))
        {
            var sql = "Delete from Employee where id = @id";
            var result = connection.Execute(sql, new { Id = id });
            return result > 0;
        }
    }
}