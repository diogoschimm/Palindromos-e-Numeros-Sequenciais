using System;
using System.Collections.Generic;
using System.Text;

namespace TratamentoTextosSequenciaNumero
{
    public class SequenciaNumero
    {
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
    }
}
