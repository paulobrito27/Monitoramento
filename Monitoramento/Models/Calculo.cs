using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Monitoramento.Models
{
    public class Calculo : Monitoramento
    {

        public Calculo(int estados, int pessoas)
        {
            this.QuantidadeEstados = estados;
            this.QuantidadePessoas = pessoas;
        }

        public (int,int) RetornaInfectado()
        {
            Random randon = new Random();
            int linha = randon.Next(1, this.QuantidadeEstados);
            int posicao = randon.Next(1, this.QuantidadePessoas);
            return (linha, posicao);
        }

    }
}
