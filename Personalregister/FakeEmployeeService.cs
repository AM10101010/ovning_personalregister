using Personalregister;
using RestaurantEmployeeRegistry;

public class FakeEmployeeService : IEmployeeService
{
    private readonly List<Employee> _employees = new();

    public void AddEmployee(Employee employee)
    {   
        _employees.Add(employee);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }
    
    public Employee GetEmployeeById(int id)
    {
         return _employees.FirstOrDefault(e => e.Id == id)!;
    }

    public void RemoveEmployee(int id)
    {
        
        var employee = GetEmployeeById(id);
        if (employee != null)
        {
            _employees.Remove(employee);
        }
    }

    public List<Employee> FindByRole(Role role)
    {
        return [.. _employees.Where(e => e.Role == role)];
    } 
}