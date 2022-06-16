namespace CRUDApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public Div Division { get; set; }
        public string Address { get; set;}
        public string Gender { get; set;}
    }

    public enum Div
    {
        IT,
        Marketing,
        HRGA,
        Accounting
    }
}