using System;
using System.Threading.Tasks;
using SampleReadFile.Factories;

namespace SampleReadFile
{
    internal class Program
    {
        public static async Task GetMethod()
        {
            IReaderFactory fact = new XmlReaderFactory();
            var reader = fact.GetInstance("Words.txt");
            //reader.ProcessReadAsync();

            var result = await reader.ProcessReadAsync();
            foreach (var person in result) Console.WriteLine("ID : " + person.Id + " Name :" + person.Name);
        }

        private static void Main(string[] args)
        {
            GetMethod().Wait();

            Console.Write("Done ");
            Console.ReadKey();
        }
    }
}