using Microsoft.VisualStudio.TestTools.UnitTesting;
using SampleReadFile.Factories;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //var result = new FileReadService().ProcessRead();

            //Assert.IsNotNull(result, "1 should not be prime");

            IReaderFactory fact = new TextReaderFactory();
            var reader = fact.GetInstance("Words.txt");
            reader.ProcessReadAsync().Start();
            //reader.ProcessRead();
        }
    }
}