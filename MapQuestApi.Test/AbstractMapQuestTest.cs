using NUnit.Framework;

namespace MapQuestApi.Test
{
    public abstract class AbstractMapQuestTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public abstract void GetResponseMustBeTrue_Test();
    }
}
