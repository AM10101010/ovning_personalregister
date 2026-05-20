namespace RestaurantEmployeeRegistry
{
    public enum Role
    {
        Staff,
        Manager,
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Role Role { get; set; }
        public decimal HourlyWage { get; set; }


        public string FullName => $"{FirstName} {LastName}";

        public override string ToString()
        {
            return $"[{Id}] {FullName,-25} | {Role,-8} | {HourlyWage,6:C} /hr";
        }
    }
}