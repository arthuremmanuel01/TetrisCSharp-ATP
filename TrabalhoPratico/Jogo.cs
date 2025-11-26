using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    internal class Jogo
    {
        Tabuleiro tabuleiro = new Tabuleiro();
        Peca pecaAtual = new Peca();

        public void Iniciar()
        {
            Jogador j1 = new Jogador();

            Console.WriteLine("Digite o seu nome: ");
            string nomeJogador = Console.ReadLine();

            j1.Nome = nomeJogador;
            pecaAtual.GerarPeca();

            j1.AdicionarPontos(pecaAtual.Pontos);
            tabuleiro.InserirPeca(pecaAtual);

            tabuleiro.Renderizar();

            bool acabou = false;

            while (acabou == false)
            {

                ConsoleKeyInfo tecla = Console.ReadKey(true);
                switch (tecla.Key)
                {
                    case ConsoleKey.LeftArrow:
                        tabuleiro.Limpar(pecaAtual);
                        pecaAtual.MoverEsquerda();

                        if (tabuleiro.PodeInserir(pecaAtual))
                        {
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        else
                        {
                            pecaAtual.MoverDireita();
                            tabuleiro.Atualizar(pecaAtual);
                        }

                        break;
                    case ConsoleKey.RightArrow:
                        tabuleiro.Limpar(pecaAtual);
                        pecaAtual.MoverDireita();

                        if (tabuleiro.PodeInserir(pecaAtual))
                        {
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        else
                        {
                            pecaAtual.MoverEsquerda();
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        tabuleiro.Limpar(pecaAtual);
                        pecaAtual.MoverBaixo();

                        if (tabuleiro.PodeInserir(pecaAtual))
                        {
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        else
                        {
                            
                            pecaAtual.MoverCima();

                            tabuleiro.Atualizar(pecaAtual);
                            tabuleiro.VerificarLinhas(pecaAtual);
                            pecaAtual.PosX = 0;
                            pecaAtual.PosY = 3;
                            
                            pecaAtual.GerarPeca();
                            j1.AdicionarPontos(pecaAtual.Pontos);
                            int n = tabuleiro.LinhasFormadas;
                            if (n != 0)
                            {
                                j1.AdicionarPontos(tabuleiro.LinhasFormadas * 300);
                                tabuleiro.LinhasFormadas = 0;
                            }
                            if (tabuleiro.PodeInserir(pecaAtual))
                            {
                                tabuleiro.InserirPeca(pecaAtual);
                                
                            }
                            else
                            {
                                acabou = true;
                                Console.Clear();
                                Console.WriteLine($"Nome do Jogador: {j1.Nome}");
                                Console.WriteLine($"Pontuação: {j1.PontuacaoFinal}");
                                j1.Salvar("pontuacoes.txt");
                            }
                            
                        }
                        break;
                    case ConsoleKey.A:
                        tabuleiro.Limpar(pecaAtual);
                        pecaAtual.RotacionarHorario();

                        if (tabuleiro.PodeInserir(pecaAtual))
                        {
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        else
                        {
                            pecaAtual.RotacionarAntiHorario();
                            tabuleiro.Atualizar(pecaAtual);
                        }
                            break;
                    case ConsoleKey.H:
                        tabuleiro.Limpar(pecaAtual);
                        pecaAtual.RotacionarAntiHorario();

                        if (tabuleiro.PodeInserir(pecaAtual))
                        {
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        else
                        {
                            pecaAtual.RotacionarHorario();
                            tabuleiro.Atualizar(pecaAtual);
                        }
                        break;
                }
                if(acabou == false)
                {
                    Console.Clear();
                    tabuleiro.Renderizar();
                }
                
            }
        }
    }
}
