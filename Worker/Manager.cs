namespace Worker
{
    /// <summary>
    /// Manager class to use to create Manager objects to Serialize/Deserialize;
    /// Krzysztof Szczurowski;
    /// BCIT COMP 3618;
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Assignment2_Serializer.git
    /// </summary>
    public class Manager : Employee
    {
        public int NoOfSubordinates { get; set; }
        public Manager() : base()
        {
        }
    }
}
