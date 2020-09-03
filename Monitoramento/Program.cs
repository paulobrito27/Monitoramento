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
            List<Infectado> lista = new List<Infectado>();



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
                lista.Add(new Infectado(infectado.Item1, infectado.Item2));

                for (int i = 1; i <= calculo.QuantidadeEstados; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (i == infectado.Item1) { Console.ForegroundColor = ConsoleColor.Red; }
                    Console.Write("Estado " + i + "\t -> ");
                    for (int j = 1; j <= calculo.QuantidadePessoas; j++)
                    {
                        bool doente = false;


                        foreach(var pessoa in lista)
                        {
                            if(pessoa.Linha == i && pessoa.Posicao == j)
                            {
                                doente = true;
                            }
                        }
                        if (doente)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write(Parametros.CaracterPessoaInfectada);
                        }
                        else
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
