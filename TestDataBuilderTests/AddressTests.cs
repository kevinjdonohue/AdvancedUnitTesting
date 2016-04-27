using FluentAssertions;
using TestDataBuilder;
using Xunit;

namespace TestDataBuilderTests
{
    public class AddressTests
    {
        [Fact]
        public void EqualsReturnsCorrectResult()
        {
            //arrange
            Address sut = new Address("line 1", "line 2", "city", "state", 12345);

            //act
            bool actual = sut.Equals(new Address("line 1", "line 2", "city", "state", 12345));

            //assert
            actual.Should().Be(true);
        }

        [Fact]
        public void AddressesShouldBeEqual()
        {
            //arrange
            Address expected = new Address("line 1", "line 2", "city", "state", 12345);

            //act
            Address actual = new Address("line 1", "line 2", "city", "state", 12345);

            //assert
            actual.ShouldBeEquivalentTo(expected);
        }

        [Fact]
        public void EqualsAnyOtherObjectReturnsFalse()
        {
            //arrange
            Address sut = new Address("line 1", "line 2", "city", "state", 12345);
            object someObject = "foo";

            //act
            bool actual = sut.Equals(someObject);

            //assert
            actual.Should().Be(false);
        }
    }
}
