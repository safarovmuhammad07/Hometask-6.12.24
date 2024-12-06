using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IEmployeeService
{
    List<Employee> getAllEmployees();
    Employee GetEmployeeById(int id);
    bool AddEmployee(Employee employee);
    bool UpdateEmployee(Employee employee);
    bool DeleteEmployee(int id);
}