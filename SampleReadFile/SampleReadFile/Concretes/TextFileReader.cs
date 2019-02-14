using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SampleReadFile.Interfaces;
using SampleReadFile.Models;

namespace SampleReadFile.Concretes
{
    public class TextFileReader : IFileReader
    {
        private readonly string _filePath;
        private readonly IContentReader _reader;

        public TextFileReader(IContentReader reader, string filePath) : base(reader, filePath)
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
                Console.WriteLine("ASYNC");
                var text = await _reader.ReadAsync(_filePath);
                var personList = (from line in text.Split(new[] { "\r\n" }, StringSplitOptions.None)
                                  select line.Split(new[] { "," }, StringSplitOptions.None)
                    into person
                                  let personId = person[0]
                                  let personName = person[1]
                                  select new Person { Id = personId, Name = personName }).ToList();

                return personList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public override bool ProcessRead()
        {
            Console.WriteLine("NOT ASYNC");
            var result = _reader.Read(_filePath);
            var personList = (from line in result.Split(new[] { "\r\n" }, StringSplitOptions.None)
                              select line.Split(new[] { "," }, StringSplitOptions.None)
                into person
                              let personId = person[0]
                              let personName = person[1]
                              select new Person { Id = personId, Name = personName }).ToList();

            foreach (var person in personList) Console.WriteLine("ID : " + person.Id + " Name :" + person.Name);
            return true;
        }
    }
}