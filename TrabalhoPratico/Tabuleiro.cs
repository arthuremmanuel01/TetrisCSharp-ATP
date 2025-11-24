using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoPratico
{
    internal class Tabuleiro

    // Atributos: 
    //  int[,] matriz – matriz de dimensões fixas (20 linhas × 10 colunas

    // Métodos:
    // - bool PodeInserir(Peca peca) – Verifica se a peça pode ser posicionada na matriz, considerando colisões e limites.
    // - void InserirPeca(Peca peca) – Posiciona a nova peça no topo da matriz, centralizada horizontalmente.
    // - void Limpar(Peca peca) – Remove a representação da peça da matriz, substituindo suas células por “vazios”.
    // - void Atualizar(Peca peca) – Insere a peça na nova posição após movimentação.
    // - void VerificarLinhas(Peca peca) – Identifica linhas completamente preenchidas, remove-as e desloca as superiores para baixo
    // - void Renderizar() – Exibe o estado atual do tabuleiro no console.


    {
        public int[,] matriz = new int[20, 10];




        public bool PodeInserir(Peca peca)
        {
            int cont = 0;
            

            if (peca.Tipo == 'I')
            {
                for (int i = 0, posX = peca.PosX; i < peca.PecaI.GetLength(0); i++, posX++)
                {
                    for (int j = 0, posY = peca.PosY; j < peca.PecaI.GetLength(1); j++, posY++)
                    {
                        if (matriz[posX, posY] != 0 && peca.PecaI[i, j] == 1 && posY < matriz.GetLength(1) - 1 && posX < matriz.GetLength(0) - 3)
                        {
                            cont++;
                        }
                    }
                }
            }

            else if (peca.Tipo == 'L')
            {
                for (int i = 0, posX = peca.PosX; i < peca.PecaI.GetLength(0); i++, posX++)
                {
                    for (int j = 0, posY = peca.PosY; j < peca.PecaI.GetLength(1); j++, posY++)
                    {
                        if (matriz[posX, posY] != 0 && peca.PecaI[i, j] == 1 && posY < matriz.GetLength(1) - 2 && posX < matriz.GetLength(0) - 3)
                        {
                            cont++;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0, posX = peca.PosX; i < peca.PecaI.GetLength(0); i++, posX++)
                {
                    for (int j = 0, posY = peca.PosY; j < peca.PecaI.GetLength(1); j++, posY++)
                    {
                        if (matriz[posX, posY] != 0 && peca.PecaI[i, j] == 1 && posY < matriz.GetLength(1) - 2 && posX < matriz.GetLength(0) - 4)
                        {
                            cont++;
                        }
                    }
                }
            }

            if (cont == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InserirPeca(Peca peca) 
        { //pos x = 0; pecax = 0


            if (PodeInserir(peca) == true)
            {
                for (int i = 0, posX = peca.PosX; i < peca.Forma.GetLength(0); i++, posX++) //peca[0,0] - matriz[0,3] ++ peca[0,1] - matriz[0,4]
                {
                    for (int j = 0, posY = peca.PosY; j < peca.Forma.GetLength(1); j++, posY++) // j = 3 = posy; j < 3 + 3 = pecay; j++
                    {
                        if (peca.Forma[i, j] == 1) //Forma[3, 3]
                        { 
                            matriz[posX, posY] = 1; //matriz[1,3] = 1
                        }
                    }
                }
            }
        }

        public void Limpar(int [,] peca) 
        { 
            for (int i = 0; i < peca.GetLength(0); i++)
            {
                for (int j = 0; i < peca.GetLength(1); i++)
                {
                    if (peca[i,j] == 1)
                    {
                        peca[i, j] = 0;
                    }
                }
            }
        }
        public void Atualizar(Peca[,] peca) { }
        public void VerificarLinhas(Peca[,] peca) { }
        public void Renderizar()
        {

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        Console.Write($" .");
                    }
                    else
                    {
                        Console.Write(" X");
                    }

                }
                Console.WriteLine();
            }
        }
            
    }
}
