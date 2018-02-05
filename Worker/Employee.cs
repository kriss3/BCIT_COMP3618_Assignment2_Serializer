namespace Worker
{
    /// <summary>
    /// Employee class to use to create Employee objects to Serialize/Deserialize;
    /// Krzysztof Szczurowski;
    /// BCIT COMP 3618;
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Assignment2_Serializer.git
    /// </summary>
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string Notes { get; set; }

        public Employee() { }
    }
}