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

        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }
        public int PontuacaoFinal
        {
            get
            {
                return pontuacaoFinal;
            }
            set
            {
                pontuacaoFinal = value;
            }
        }

        public void AdicionarPontos(int pontos)
        {
            pontuacaoFinal += pontos;
        }

        public void Salvar(string caminho)
        {
            try
            {
                StreamWriter arq = new StreamWriter(caminho, true, Encoding.UTF8);
                arq.WriteLine($"{nome}: {pontuacaoFinal}");
                arq.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção lançada ao escrever no arquivo de pontuações: " + e.Message);
            }
        }
    }
}
