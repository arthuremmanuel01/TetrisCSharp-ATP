using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
/*Conteúdo e Funcionalidades
  → mover para direita
• ← mover para esquerda
• ↓ mover para baixo
• a rotacionar 90º sentido anti-horário
• h rotacionar 90º sentido horário
• Tabuleiro: utilizar uma matriz bidimensional como base do jogo (Matriz 20 × 10)
• Peça: implementar os três formatos clássicos I, L, T (Matriz 3x3)
Cada linha completa removida concede pontos ao jogador (300 pontos).
A pontuação para encaixar cada peça deve ser diferente. Sendo (I = 3, L = 4, T = 5)
O jogo será encerrado quando essa nova peça não puder ser inserida no
tabuleiro devido à falta de espaço, ou seja, quando a área de inserção estiver ocupada por outras peças
já fixadas.
Registro de pontuação: gravar o nome do jogador e sua respectiva pontuação final em um arquivo texto
(pontuacoes.txt). O arquivo deve ter o seguinte formato: NomeJogador;Pontuação
*/
    internal class Program
    {
        static void Main(string[] args)
        {
            Peca p1 = new Peca();
            p1.GerarPeca();
            Tabuleiro t1 = new Tabuleiro();


            /*Console.WriteLine("----- Anti Horário -----");
            Console.WriteLine();
            p1.RotacionarAntiHorario();
            Console.WriteLine();
            p1.RotacionarAntiHorario();
            Console.WriteLine();
            p1.RotacionarAntiHorario();
            Console.WriteLine();
            p1.RotacionarAntiHorario();
            Console.WriteLine();
            Console.ResetColor();*/

            t1.PodeInserir(p1);
            t1.InserirPeca(p1);
            t1.Renderizar();
        }
    }
}
