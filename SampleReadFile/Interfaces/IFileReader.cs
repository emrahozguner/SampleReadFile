using System.Collections.Generic;
using System.Threading.Tasks;
using SampleReadFile.Models;

namespace SampleReadFile.Interfaces
{
    public abstract class IFileReader
    {
        public IFileReader(IContentReader reader, string filePath)
        {
        }

        public abstract Task<List<Person>> ProcessReadAsync();

        public abstract bool ProcessRead();
    }
}