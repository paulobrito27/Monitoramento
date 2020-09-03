using Monitoramento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Monitoramento
{
    class Program
    {
        static void Main(string[] args)
        {
            Parametros.CaracterPessoaInfectada = " # ";
            Parametros.CaracterPessoaSaudavel = " - ";
            Parametros.TempoDeMonitoramento = 60;
            

            List<(int, int)> lista2 = new List<(int, int)>();

            var valores = Parametros.Questionario();
            Calculo calculo = new Calculo(valores.Item1, valores.Item2);

            Console.Clear();

            for (int i = 1; i <= calculo.QuantidadeEstados; i++)
            {

                Console.Write("Estado " + i + "\t -> ");
                for (int j = 1; j <= calculo.QuantidadePessoas; j++)
                {
                    Console.Write(Parametros.CaracterPessoaSaudavel);
                }
                Console.WriteLine();
            }

            for (int k = 1; k <= Parametros.TempoDeMonitoramento; k++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                
                var infectado = calculo.RetornaInfectado();
                lista2.Add(infectado);
                

                for (int i = 1; i <= calculo.QuantidadeEstados; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == infectado.Item1) { Console.ForegroundColor = ConsoleColor.Red; }
                    Console.Write("Estado " + i + "\t -> ");
                    for (int j = 1; j <= calculo.QuantidadePessoas; j++)
                    {
                        bool saudavel = true;
                        foreach (var pessoa in lista2)
                        {
                            if(pessoa.Item1 == i && pessoa.Item2 == j)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write(Parametros.CaracterPessoaInfectada);
                                saudavel = false;
                            }   
                        }
                        if (saudavel)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(Parametros.CaracterPessoaSaudavel);
                        }
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
