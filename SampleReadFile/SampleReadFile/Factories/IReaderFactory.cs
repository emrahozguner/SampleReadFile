using SampleReadFile.Concretes;
using SampleReadFile.Interfaces;

namespace SampleReadFile.Factories
{
    public interface IReaderFactory
    {
        IFileReader GetInstance(string filePath);
    }

    public class TextReaderFactory : IReaderFactory
    {
        public IFileReader GetInstance(string filePath)
        {
            IContentFactory contentFactory = new TextContentFactory();
            return new TextFileReader(contentFactory.GetInstance(), filePath);
        }
    }

    public class XmlReaderFactory : IReaderFactory
    {
        public IFileReader GetInstance(string filePath)
        {
            IContentFactory contentFactory = new XmlContentFactory();
            return new XmlFileReader(contentFactory.GetInstance(), filePath);
        }
    }
}