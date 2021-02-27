# Palíndromos e Números Sequenciais

Verificação de Textos Palíndromo, Transformação de Texto para Palíndromo e Números Sequenciais

## Verificação se o texto é um Palíndromo

Algoritmo para verificação se o texto é um palíndromo sem usar funções prontas do .net

```c#
  public bool IsPalindromo(string texto)
  {
      var textoTratado = ObterTextoTratadoParaValidarPalindromo(texto);
      var textoInvertido = StrReversePalindromo(textoTratado);

      return textoTratado.Equals(textoInvertido, StringComparison.InvariantCultureIgnoreCase);
  }
  
  public string StrReversePalindromo(string texto)
  {
      var textoFinal = "";
      for (int i = 0; i < texto.Length; i++)
      {
          var caractere = texto[i];
          if (IsCaracterePermitido(caractere))
              textoFinal = caractere + textoFinal;
      }

      return textoFinal;
  }

  private string ObterTextoTratadoParaValidarPalindromo(string texto)
  {
      var textoFinal = "";
      for (int i = 0; i < texto.Length; i++)
      {
          var caractere = texto[i];
          if (IsCaracterePermitido(caractere))
              textoFinal += caractere;
      }

      return textoFinal;
  }

  private bool IsCaracterePermitido(char caractere)
  {
      if (IsLetraMaiuscula(caractere) || IsLetraMinuscula(caractere))
          return true;

      return false;
  }

  private bool IsLetraMaiuscula(char ascii) => ascii >= 65 && ascii <= 90;
  private bool IsLetraMinuscula(char ascii) => ascii >= 97 && ascii <= 122;
```

## Tratamento de texto palíndromo

Remover o caractere errado da string para tornar o texto um palíndromo.

```c#
  public (string, int) TransformarPalindromo(string textoModificado)
  {
      string novoTexto = "";
      int i = 0;

      // 012345
      // matam
      // matamn

      for (i = 0; i < textoModificado.Length; i++)
      {
          if (i == 0)
              novoTexto = textoModificado[1..];

          else if (i == textoModificado.Length - 1)
              novoTexto = textoModificado.Substring(0, i);

          else
              novoTexto = textoModificado.Substring(0, i) + textoModificado[(i + 1)..];

          if (IsPalindromo(novoTexto))
              break;
      }

      return (novoTexto, i);
  }
```

## Sequencia de números 

Ao digitar um número qualquer, como por exemplo 8 o algoritmo deve retornar 12345678, se digitar 14 deve retornar 1234567891011121314

```c#
  public long ObterSequencia(long numero)
  {
      // 4
      // 1234
      // 1000 + (10^3) * 1
      //  200 + (10^2) * 2
      //   30 + (10^1) * 3
      //    4   (10^0) * 4

      if (numero == 1)
          return numero;

      long soma = 0;
      for (int i = 1; i <= numero; i++)
      {
          if (i < 10)
          {
              var exp = Min(10, numero) - i;
              var potencia = Potencia(10, exp) * i;
              soma += potencia;
          }
          else if (i >= 10)
          {
              soma *= (i == 10) ? 10 : 100;
              soma += i;
          }
      }

      return soma;
  }

  public long Min(long valor, long valor2)
  {
      if (valor > valor2)
          return valor2;

      return valor;
  }

  public long Potencia(long baseCalculo, long expoente)
  {
      long total = 1;
      for (int i = 1; i <= expoente; i++)
          total *= baseCalculo;

      return total;
  }
```

## Testes únitários para o métodos de String e de Sequência 

```c# 
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
```

## Teste da Sequência de Números

```c# 
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
```

