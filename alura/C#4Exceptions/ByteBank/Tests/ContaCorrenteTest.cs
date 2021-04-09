using System;
using Xunit;

namespace _01_ByteBank.Tests
{
    public static class Tests
    {
        [Fact]
        public static void Init(){
            TesteContaCorrente();
        }
         
        [Fact]
        public static void TesteContaCorrente(){
            Assert.Throws<Exception>( () => new ContaCorrente(numeroAgencia: -15, numeroConta: 25, titular:new Cliente("a", 12, "12")));            
        }

    }
}


