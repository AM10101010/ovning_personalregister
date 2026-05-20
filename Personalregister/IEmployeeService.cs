using RestaurantEmployeeRegistry;

namespace Personalregister
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        void RemoveEmployee(int id);
    }
}