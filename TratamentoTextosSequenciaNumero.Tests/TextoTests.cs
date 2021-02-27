using System;
using Xunit;

namespace TratamentoTextosSequenciaNumero.Tests
{
    public class TextoTests
    {
        private readonly Texto _texto;

        public TextoTests()
        {
            this._texto = new Texto();
        }

        [Fact]
        [Trait("Texto","Teste de Palindromo")]
        public void ProgramTests_StrReverse_DeveRetornarTrueParaTextoPalindromo()
        {
            // Arrange
            var texto = "racecar";

            // Act
            var textoInvertido = _texto.StrReversePalindromo(texto);

            // Assert
            Assert.Equal(expected: "racecar", textoInvertido);
        }

        [Fact]
        [Trait("Texto", "Teste de Reverse")]
        public void ProgramTests_StrReverse_DeveRetornarFalsoParaTextoNaoPalindromo()
        {
            // Arrange
            var texto = "banana";

            // Act
            var textoInvertido = _texto.StrReversePalindromo(texto);

            // Assert
            Assert.Equal(expected: "ananab", textoInvertido);
        }

        [Theory]
        [InlineData("racecar")]
        [InlineData("ana")]
        [InlineData("matam")]
        [InlineData("mussum")]
        [InlineData("reger")]
        [InlineData("socos")]
        [InlineData("A mala nada na lama")]
        [InlineData("A grama é amarga")]
        [InlineData("Roma me tem amor")]
        [InlineData("Anotaram a data da maratona")] 
        [InlineData("Socorram-me, subi no onibus em Marrocos")]
        [InlineData("Soluco me sem oculos")]
        [Trait("Texto", "Teste de Palindromo")]
        public void ProgramTests_IsPalindromo_DeveRetornarTrueParaTextoPalindromo(string texto)
        {
            // Act
            var isPalindromo = _texto.IsPalindromo(texto);

            // Assert
            Assert.True(isPalindromo);
        }

        [Fact]
        [Trait("Texto", "Teste de Palindromo")]
        public void ProgramTests_IsPalindromo_DeveRetornarFalseParaTextoNaoPalindromo()
        {
            // Arrange
            var texto = "banana";

            // Act
            var isPalindromo = _texto.IsPalindromo(texto);

            // Assert
            Assert.False(isPalindromo);
        }


        [Theory]
        [InlineData("atna", 1, "ana")]
        [InlineData("racyecar", 3, "racecar")]
        [InlineData("matamn", 5, "matam")]
        [InlineData("A mala nada nca lama", 13, "A mala nada na lama")]
        [Trait("Texto", "Transformação Palindromo")]
        public void TextoTests_TransformarPalindromo_DeveRetornoTextoPalindromo(string textoModificado, int indiceEsperado, string textoEsperado)
        {
            // Act
            var (novoTexto, indice) = _texto.TransformarPalindromo(textoModificado);

            // Assert
            Assert.Equal(indiceEsperado, indice);
            Assert.Equal(textoEsperado, novoTexto);
        }
    }
}
