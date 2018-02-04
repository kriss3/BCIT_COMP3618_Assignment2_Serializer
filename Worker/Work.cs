using System.IO;
using System.Xml.Serialization;

namespace Worker
{
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
