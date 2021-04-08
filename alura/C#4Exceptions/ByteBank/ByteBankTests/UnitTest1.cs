using System;
using Xunit;

namespace ByteBankTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(4, Add(2,2));
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(7)]
        public void Test2(int value){
            Assert.True(isOdd(value));
        }
        int Add(int n1, int n2 ){
            return n1+n2;
        }

        bool isOdd(int n) {
            return n % 2 == 1;
        }
    }
}
