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



        private int posX = 0, posY = 3;
        private char tipo;
        private int pontos;
        private int[,] forma = new int[3, 3];
        private int[,] matInvert = new int[3, 3];

        public int[,] PecaI
        {
            get
            {
                return pecaI;
            }
        }
        public int[,] PecaL 
        {
            get
            {
                return pecaL;
            }
        }
        public int[,] PecaT
        {
            get
            {
                return pecaT;
            }
        }
        public char Tipo 
        {
            get
            {
                return tipo;
            }
        }
        public int[,] Forma 
        {
            get
            {
                return forma;
            }
        }
        public int PosX 
        {
            get
            {
                return posX;
            }
            set
            {
                posX = value;
            } 
        }
        public int PosY {
            get
            {
                return posY;
            }
            set
            {
                posY = value;
            }
        }
        public int Pontos {
            get
            {
                return pontos;
            }
            set
            {
                pontos = value;
            } 
        }


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
                    break;
                case 2:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Forma[i, j] = PecaT[i, j];
                    }
                    tipo = 'T';
                    break;
                case 3:
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                            Forma[i, j] = PecaL[i, j];
                    }
                    tipo = 'L';
                    break;
                default:
                    break;
            }

            switch (tipo)
            {
                case 'I':
                    pontos = 3;
                    break;

                case 'T':
                    pontos = 5;
                    break;

                case 'L':
                    pontos = 4;
                    break;
                default:
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
                    Forma[i, j] = matInvert[i, j];
                }
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
                    Forma[i, j] = matInvert[i, j];
                }
            }
        }
        public void MoverEsquerda()
        {
            PosY--;
        }
        public void MoverDireita()
        {
            PosY++;
        }
        public void MoverBaixo()
        {
            PosX++;
        }
        public void MoverCima()
        {
            PosX--;
        }
    }
}