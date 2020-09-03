using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Monitoramento.Models
{
    public static class Parametros
    {
        public static string CaracterPessoaSaudavel { get; set; }
        public static string CaracterPessoaInfectada { get; set; }
        public static int TempoDeMonitoramento { get; set; }

        private static string ConfiguraEstados()
        {
            Console.WriteLine("Quantos estados deseja monitorar?");
            var resposta = Console.ReadLine();
            return resposta;
        }

        private static string ConfiguraPessoas()
        {
            Console.WriteLine("Quantas pessoas deseja monitorar?");
            var resposta = Console.ReadLine();
            return resposta;
        }

        private static void ImprimeErro(this string s)
        {
            Console.WriteLine(s);
        }

        private static bool ValidaStringDigitada(string s)
        {
            bool valida = false;

            foreach (char digito in s)
            {
                valida = char.IsDigit(digito);
            }
            return valida;
        }

        private static int QuestionarioSecundario()
        {
            string resposta;
            bool validado = false;
            do
            {
                resposta = ConfiguraPessoas();
                validado = ValidaStringDigitada(resposta);
                if (!validado)
                {
                    "Informe um número".ImprimeErro();
                    Thread.Sleep(1000);
                    Console.Clear();
                }

            } while (!validado);

            return Convert.ToInt32(resposta);
        }


        public static (int, int) Questionario()
        {

            bool validado = false;
            string resposta1;
            int numeroEstados = 0;
            do
            {
                resposta1 = ConfiguraEstados();
                validado = ValidaStringDigitada(resposta1);
                if (!validado)
                {
                    ImprimeErro("Informe um número");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    numeroEstados = Convert.ToInt32(resposta1);
                    if (numeroEstados > 27)
                    {
                        ImprimeErro("No Brasil temos apenas 27 estados");
                        Thread.Sleep(1000);
                        Console.Clear();
                        validado = false;
                    }
                }
            } while (!validado);

            var numeroPessoas = QuestionarioSecundario();
            return (numeroEstados, numeroPessoas);
        }
    }
}
