using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace lab_10_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // створити новий об'єкт Person
            Person person = new Person("John Doe", new DateTime(1990, 5, 10));

            // серіалізуємо об'єкт у файл
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Person));
            using (FileStream stream = File.Create("person.json"))
            {
                serializer.WriteObject(stream, person);
            }

            // десеріалізація об'єкта з файлу
            using (FileStream stream = File.OpenRead("person.json"))
            {
                Person deserializedPerson = (Person)serializer.ReadObject(stream);
                deserializedPerson.OutPut(); // друкуємо інформацію про десеріалізовану особу
            }
        }
    }
}

