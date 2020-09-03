using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monitoramento.Models
{
    public class Infectado
    {
        public int Linha { get; set; }

        public int Posicao { get; set; }

        public Infectado(int linha, int posicao)
        {
            Linha = linha;
            Posicao = posicao;
        }
    }
}
