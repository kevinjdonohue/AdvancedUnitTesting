using Moq;

namespace TestDataBuilderTests
{
    public static class MockEnvy
    {
        public static Mock<T> AsMock<T>(this T obj) where T : class
        {
            return Mock.Get(obj);
        }
    }
}
