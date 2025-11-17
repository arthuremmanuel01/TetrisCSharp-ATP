using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    internal class Peca
    {
        private int[,] pecaI = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 0 } };
        private int[,] l = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };
        private int[,] t = { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } };
        Tabuleiro tabuleiro = new Tabuleiro();



        public int posX = 0, posY = 3;
        char tipo;
        int pontos;
        int[,] forma = new int[3, 3];
        int[,] matInvert = new int[3, 3];
        public void GerarPeca()
        {
            Random r = new Random();
            int num = r.Next(1, 4);

            switch (num)
            {
                case 1:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            forma[i, j] = pecaI[i, j];
                    }

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            forma[i, j] = t[i, j];
                    }

                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            forma[i, j] = l[i, j];
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
            }
        }

        public void RotacionarHorario()
        {

            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    matInvert[i, 2 - j] = forma[j, i];

                }
            }

            for (int i = 0; i < matInvert.GetLength(0); i++)
            {
                for (int j = 0; j < matInvert.GetLength(1); j++)
                {
                    Console.Write($"{matInvert[i, j]} ");
                    forma[i, j] = matInvert[i, j];
                }
                Console.WriteLine();
            }
        }
        public void RotacionarAntiHorario()
        {
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    matInvert[2 - j, i] = forma[i, j];
                }
            }

            for (int i = 0; i < matInvert.GetLength(0); i++)
            {
                for (int j = 0; j < matInvert.GetLength(1); j++)
                {
                    Console.Write($"{matInvert[i, j]} ");
                    forma[i, j] = matInvert[i, j];
                }
                Console.WriteLine();
            }
        }
        void MoverEsquerda()
        {
            if (posX > 0)
            {
                posX--;

            }
        }
        void MoverDireita()
        {
            if (posX < 8)
            {
                posX++;
                tabuleiro.Limpar(forma);
            }
        }
        void MoverBaixo()
        {
            if (posY < 18)
            {
                posY--;

            }
        }
    }
}

/*Dica da Professora:
 * ConsoleKeyInfo tecla = Console.ReadKey(true);
switch (tecla.Key)
{
case ConsoleKey.LeftArrow:
Console.WriteLine("Seta para ESQUERDA pressionada");
break;
case ConsoleKey.RightArrow:
Console.WriteLine("Seta para DIREITA pressionada");
break;
case ConsoleKey.DownArrow:
Console.WriteLine("Seta para BAIXO pressionada");
break;
case ConsoleKey.A:
Console.WriteLine("A pressionada");
break;
case ConsoleKey.H:
Console.WriteLine("H pressionada");
break;
}
*/ 