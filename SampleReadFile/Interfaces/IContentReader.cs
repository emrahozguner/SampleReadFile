using System.Threading.Tasks;

namespace SampleReadFile.Interfaces
{
    public abstract class IContentReader
    {
        public abstract Task<string> ReadAsync(string filePath);

        public abstract string Read(string filePath);
    }
}