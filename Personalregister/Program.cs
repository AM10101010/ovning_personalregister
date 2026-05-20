using RestaurantEmployeeRegistry;

var employeeService = new EmployeeService();

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
            // Code to find employee by ID
            break;
        case "4":
            // Code to remove employee
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