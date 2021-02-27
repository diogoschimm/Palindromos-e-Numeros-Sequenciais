using System;

namespace TratamentoTextosSequenciaNumero
{
    public class Texto
    {
        public bool IsPalindromo(string texto)
        {
            var textoTratado = ObterTextoTratadoParaValidarPalindromo(texto);
            var textoInvertido = StrReversePalindromo(textoTratado);

            return textoTratado.Equals(textoInvertido, StringComparison.InvariantCultureIgnoreCase);
        }

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
    }
}
