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
        private int[,] pecaL = { { 0, 1, 0 }, { 0, 1, 0 }, { 0, 1, 1 } };
        private int[,] pecaT = { { 1, 1, 1 }, { 0, 1, 0 }, { 0, 1, 0 } };
        Tabuleiro tabuleiro = new Tabuleiro();



        private int posX = 17, posY = 0;
        private char tipo;
        int pontos;
        private int[,] forma = new int[3, 3];
        int[,] matInvert = new int[3, 3];

        public int[,] PecaI { get => pecaI;}
        public int[,] PecaL { get => pecaL;}
        public int[,] PecaT { get => pecaT;}
        public char Tipo { get => tipo;}
        public int PosX { get => posX; }
        public int PosY { get => posY;}
        public int[,] Forma { get => forma;}

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
                            Forma[i, j] = PecaI[i, j];                           
                    }
                    tipo = 'I';

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Forma[i, j] = PecaT[i, j];
                    }
                    tipo = 'T';
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Forma[i, j] = PecaL[i, j];
                    }
                    tipo = 'L';
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
                    matInvert[i, 2 - j] = Forma[j, i];

                }
            }

            for (int i = 0; i < matInvert.GetLength(0); i++)
            {
                for (int j = 0; j < matInvert.GetLength(1); j++)
                {
                    Console.Write($"{matInvert[i, j]} ");
                    Forma[i, j] = matInvert[i, j];
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
                    matInvert[2 - j, i] = Forma[i, j];
                }
            }

            for (int i = 0; i < matInvert.GetLength(0); i++)
            {
                for (int j = 0; j < matInvert.GetLength(1); j++)
                {
                    Console.Write($"{matInvert[i, j]} ");
                    Forma[i, j] = matInvert[i, j];
                }
                Console.WriteLine();
            }
        }
        void MoverEsquerda()
        {
            if (PosX > 0)
            {
                posX--;

            }
        }
        void MoverDireita()
        {
            if (PosX < 8)
            {
                posX++;
                tabuleiro.Limpar(Forma);
            }
        }
        void MoverBaixo()
        {
            if (PosY < 18)
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