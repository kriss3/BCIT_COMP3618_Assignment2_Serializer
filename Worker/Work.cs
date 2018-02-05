using System.IO;
using System.Xml.Serialization;

namespace Worker
{
    /// <summary>
    /// Work class as a wrapper for Serializatiom/Deserializatin;
    /// Krzysztof Szczurowski;
    /// BCIT COMP 3618;
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Assignment2_Serializer.git
    /// </summary>
    public class Work
    {
        public static void DoSerialize(Employee emp)
        {
            using (var fs = new FileStream("EmployeeData.xml", FileMode.Create))
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(Employee));
                xSerializer.Serialize(fs, emp);
            }
        }

        public static Employee DoDeserialize()
        {
            Employee myEmp = null;
            using (var fs = new FileStream("EmployeeData.xml", FileMode.Open))
            {
                var xDSerialize = new XmlSerializer(typeof(Employee));
                var dEmp = (Employee)xDSerialize.Deserialize(fs);
                myEmp = dEmp;
            }
            return myEmp;
        }
    }
}
