using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SampleReadFile.Interfaces;
using SampleReadFile.Models;

namespace SampleReadFile.Concretes
{
    public class XmlFileReader : IFileReader
    {
        private readonly string _filePath;
        private readonly IContentReader _reader;

        public XmlFileReader(IContentReader reader, string filePath) : base(reader, filePath)
        {
            _filePath = filePath;
            _reader = reader;
        }

        public override async Task<List<Person>> ProcessReadAsync()
        {
            //var filePath = "Words.txt";
            if (File.Exists(_filePath) == false)
            {
                Console.WriteLine("file not found: " + _filePath);
                return null;
            }

            try
            {
                var text = await _reader.ReadAsync(_filePath);
                var personList = (from line in text.Split(new[] { "\r\n" }, StringSplitOptions.None)
                                  select line.Split(new[] { "," }, StringSplitOptions.None)
                    into person
                                  let personId = person[0]
                                  let personName = person[1]
                                  select new Person { Id = personId, Name = personName }).ToList();
                return personList;

                //foreach (var person in personList) Console.WriteLine("ID : " + person.Id + " Name :" + person.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override bool ProcessRead()
        {
            var result = _reader.Read(_filePath);
            return true;
        }
    }
}