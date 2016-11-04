using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

/*
Develop class Book with fields containing information about certain book and ability to load/safe contents of object from/to JSON and XML files.
*/

namespace NineteenthTask
{
    [DataContract]
    class Book
    {
        [DataMember]
        public string Name { get; set; } = "The Time Machine";
        [DataMember]
        public string Author { get; set; } = "Herbert George Wells";
        [DataMember]
        public int PublishingYear { get; set; } = 1895;
        [DataMember]
        public string Genre { get; set; } = "Science fiction novel";
        
        public void SaveToXML()
        {
            using (Stream stream = new FileStream("data.xml", FileMode.Create))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Book));
                ser.WriteObject(stream, this);
                Console.WriteLine("Data saved to XML file.");
            }
        }

        public void LoadFromXML()
        {
            using (Stream stream = new FileStream("data.xml", FileMode.Open))
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Book));
                Book result = (Book)ser.ReadObject(stream);
                Console.WriteLine("\nReceived data from XML file:" + result);
            }
        }

        public void SaveToJSON()
        {
            using (Stream stream = new FileStream("data.json", FileMode.Create))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Book));
                ser.WriteObject(stream, this);
                Console.WriteLine("Data saved to JSON file.");
            }
        }

        public void LoadFromJSON()
        {
            using (Stream stream = new FileStream("data.json", FileMode.Open))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Book));
                Book result = (Book)ser.ReadObject(stream);
                Console.WriteLine("\nReceived data from JSON file:" + result);
            }
        }

        public override string ToString()
        {
            return "\nName: " + Name + "\nAuthor: " + " " + Author + "\nPublishingYear: " + PublishingYear + "\nGenre: " + Genre;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book b = new Book();
            b.SaveToXML();
            b.SaveToJSON();
            b.LoadFromXML();
            b.LoadFromJSON();
        }
    }
}
