using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    internal class Jogador
    {
        private String nome;
        private int pontuacaoFinal = 0;

        public string Nome { get => nome; set => nome = value; }
        public int PontuacaoFinal { get => pontuacaoFinal; set => pontuacaoFinal = value; }

        public void AdicionarPontos(int pontos) { 
            pontuacaoFinal += pontos;
        }

        public void Salvar(string caminho)
        {

        }
    }
}
