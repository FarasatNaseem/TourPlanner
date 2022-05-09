namespace MapQuestApi.Test
{
    using NUnit.Framework;
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