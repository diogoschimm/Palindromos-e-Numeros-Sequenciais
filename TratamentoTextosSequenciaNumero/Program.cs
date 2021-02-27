using System;

namespace TratamentoTextosSequenciaNumero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ExibirTelaPalindromo();

            ExibirTelaCorrigirPalindromo();

            ExibirtelaSequenciaNumero();
        }

        static void ExibirTelaPalindromo()
        {
            Console.WriteLine("Informe o texto que deseja verificar: ");
            var textoDigitado = Console.ReadLine();

            var texto = new Texto();
            Console.WriteLine(texto.IsPalindromo(textoDigitado));
        }

        static void ExibirTelaCorrigirPalindromo()
        {
            Console.WriteLine("Informe o texto que deseja corrigir: ");
            var textoDigitado = Console.ReadLine();

            var texto = new Texto();
            if (texto.IsPalindromo(textoDigitado))
            {
                Console.WriteLine("-1");
            }
            else
            { 
                var (novoTexto, indice) = texto.TransformarPalindromo(textoDigitado);

                Console.WriteLine($"Palindromo {novoTexto}");
                Console.WriteLine($"Indice incorreto {indice}");
            }
        }

        static void ExibirtelaSequenciaNumero()
        {
            Console.WriteLine("Informe o número que deseja exibir: ");
            long numero = long.Parse(Console.ReadLine());

            var sequenciaNumero = new SequenciaNumero();
            long resultado = sequenciaNumero.ObterSequencia(numero);

            Console.WriteLine(resultado);
        }
    }
}
