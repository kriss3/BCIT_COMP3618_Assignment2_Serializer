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
        public static void DoSerialize(Manager manager)
        {
            using (var fs = new FileStream("ManagerData.xml", FileMode.Create))
            {
                XmlSerializer xSerializer = new XmlSerializer(typeof(Manager));
                xSerializer.Serialize(fs, manager);
            }
        }

        public static Manager DoDeserialize()
        {
            Manager manager = null;
            using (var fs = new FileStream("ManagerData.xml", FileMode.Open))
            {
                var xDSerialize = new XmlSerializer(typeof(Manager));
                manager = (Manager)xDSerialize.Deserialize(fs);
            }
            return manager;
        }
    }
}
