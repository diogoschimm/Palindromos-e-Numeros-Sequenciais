using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TratamentoTextosSequenciaNumero.Tests
{
    public class SequenciaNumeroTests
    {
        private readonly SequenciaNumero _sequenciaNumero;
        public SequenciaNumeroTests()
        {
            _sequenciaNumero = new SequenciaNumero();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 12)]
        [InlineData(3, 123)]
        [InlineData(4, 1234)]
        [InlineData(5, 12345)]
        [InlineData(6, 123456)]
        [InlineData(7, 1234567)]
        [InlineData(8, 12345678)]
        [InlineData(9, 123456789)]
        [InlineData(10, 12345678910)]
        [InlineData(11, 1234567891011)]
        [InlineData(12, 123456789101112)]
        [InlineData(13, 12345678910111213)]
        [InlineData(14, 1234567891011121314)]
        [Trait("Sequência Números", "Obter Sequência")]
        public void SequenciaNumero_ObterSequencia_DeveRetornarSequenciaCorreta(long numero, long resultadoEsperado)
        {
            // Act 
            var resultadoCalculado = _sequenciaNumero.ObterSequencia(numero);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculado);
        }

        [Theory]
        [InlineData(10, 2, 2)]
        [InlineData(2, 5, 2)]
        [InlineData(8, 15, 8)]
        [InlineData(7, 4, 4)]
        [InlineData(150, 20, 20)]
        [Trait("Sequência Números", "Min")]
        public void SequenciaNumero_Min_DeveRetornarMenorNumero(long valor1, long valor2, long esperado)
        {
            // Act 
            var resultadoCalculado = _sequenciaNumero.Min(valor1, valor2);

            // Assert
            Assert.Equal(esperado, resultadoCalculado);
        }

        [Theory]
        [InlineData(10, 0, 1)]
        [InlineData(10, 1, 10)]
        [InlineData(10, 2, 100)]
        [InlineData(10, 3, 1000)]
        [InlineData(10, 4, 10000)]
        [InlineData(10, 5, 100000)]
        [InlineData(10, 6, 1000000)]
        [InlineData(10, 7, 10000000)]
        [InlineData(10, 8, 100000000)]
        [InlineData(10, 9, 1000000000)]
        [Trait("Sequência Números", "Potência")]
        public void SequenciaNumero_Potencia_DeveRetornarPotenciaCorreta(long baseCalculado, long expoente, long resultadoEsperado)
        {
            // Act 
            var resultadoCalculado = _sequenciaNumero.Potencia(baseCalculado, expoente);

            // Assert
            Assert.Equal(resultadoEsperado, resultadoCalculado);
        }
    }
}
