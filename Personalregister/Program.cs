using Personalregister;
using RestaurantEmployeeRegistry;

//IEmployeeService employeeService = new FakeEmployeeService();
IEmployeeService employeeService = new EmployeeService();

employeeService.AddEmployee(new Employee
{
    Id = 1,
    FirstName = "Peter",
    LastName = "Parker",
    Role = Role.Staff,
    HourlyWage = 15.50m,
});

employeeService.AddEmployee(new Employee
{
    Id = 2,
    FirstName = "Mary",
    LastName = "Jane",
    Role = Role.Manager,
    HourlyWage = 25.00m,
});

Console.WriteLine("All Employees:");

// Test: Get all employees
foreach (var employee in employeeService.GetAllEmployees())
{
    Console.WriteLine(employee);
}

Console.WriteLine("=================================");
Console.WriteLine("\nPersonregister");
Console.WriteLine("=================================");

while (true)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Lägg till anställd");
    Console.WriteLine("2. Visa alla anställda");
    Console.WriteLine("3. Sök anställd efter ID");
    Console.WriteLine("4. Ta bort anställd");
    Console.WriteLine("0. Avsluta   ");

    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            AddEmployee();
            break;
        case "2":
            ListAllEmployees();
            break;
        case "3":
            FindEmployeeById();
            break;
        case "4":
            RemoveEmployee();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Ogiltigt val, försök igen.");
            break;
    }
}

void ListAllEmployees()
{
    var employees = employeeService.GetAllEmployees();

    if (employees.Count == 0)
    {
        Console.WriteLine("Finns inga registrerade personer.");
        return;
    }

    Console.WriteLine("\nAnställda:");

    foreach (var emp in employees)
    {
        Console.WriteLine(emp);
    }
}

void AddEmployee()
{
    Console.WriteLine("Ange förnamn:");
    var firstName = Console.ReadLine();

    Console.WriteLine("Ange efternamn:");
    var lastName = Console.ReadLine();

    Console.WriteLine("Ange roll:");
    
    var roleInput = Console.ReadLine();
    if (!Enum.TryParse<Role>(roleInput, out var role))
    {
        Console.WriteLine("Ogiltig roll, försök igen.");
        return;
    }

    Console.WriteLine("Ange timlön:");
    if (!decimal.TryParse(Console.ReadLine(), out var hourlyWage))
    {
        Console.WriteLine("Ogiltig timlön, försök igen.");
        return;
    }

    var newEmployee = new Employee
    {
        Id = employeeService.GetAllEmployees().Count + 1,
        FirstName = firstName ?? string.Empty,
        LastName = lastName ?? string.Empty,
        Role = role,
        HourlyWage = hourlyWage,
    };

    employeeService.AddEmployee(newEmployee);
    Console.WriteLine("Anställd tillagd!");
}
void FindEmployeeById()
{
    Console.WriteLine("Ange ID för att söka:");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Ogiltigt ID, försök igen.");
        return;
    }

    var employee = employeeService.GetEmployeeById(id);
    if (employee != null)
    {
        Console.WriteLine(employee);
    }
    else
    {
        Console.WriteLine("Ingen anställd hittades med det ID:t.");
    }
}

void RemoveEmployee()
{
    Console.WriteLine("Ange ID för att ta bort:");
    if (!int.TryParse(Console.ReadLine(), out var id))
    {
        Console.WriteLine("Ogiltigt ID, försök igen.");
        return;
    }

    employeeService.RemoveEmployee(id);
    Console.WriteLine("Anställd borttagen.");
}      