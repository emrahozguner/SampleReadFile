using SampleReadFile.Concretes;
using SampleReadFile.Interfaces;

namespace SampleReadFile.Factories
{
    public interface IContentFactory
    {
        IContentReader GetInstance();
    }

    public class TextContentFactory : IContentFactory
    {
        public IContentReader GetInstance()
        {
            return new TextContentReader();
        }
    }

    public class XmlContentFactory : IContentFactory
    {
        public IContentReader GetInstance()
        {
            return new XmlContentReader();
        }
    }
}