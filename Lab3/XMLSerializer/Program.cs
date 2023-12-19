using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace XmlSerialization
{
    public class XmlObjectSerializer<T>
    {
        public List<T> ReadDataFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
                using (TextReader reader = new StreamReader(filePath))
                {
                    return (List<T>)serializer.Deserialize(reader);
                }
            }

            return new List<T>();
        }

        public void WriteDataToFile(List<T> objects, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, objects);
            }
        }
    }
}
