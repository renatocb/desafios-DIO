using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora.Services;

namespace CalculadoraTestes
{
    public class ValiacoesStringTests
    {
        private ValidacoesString _validacoesString;

        public ValiacoesStringTests()
        {
            _validacoesString = new ValidacoesString();
        }

        [Theory]
        [InlineData("Ola")]
        [InlineData("123")]
        [InlineData("456")]
        public void DeveContar3CaracteresEmOlaRetornar(string texto)
        {
            //Act
            int resultado = _validacoesString.ContarCaractere(texto);

            //Assert            
            Assert.Equal(3, resultado);
        }

    }
}