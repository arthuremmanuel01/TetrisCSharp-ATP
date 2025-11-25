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
        public int[,] matriz = {
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 0, 0, 0, 0, 0, 0, 0, 0, 2 },
            { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 }
        };

        private int linhasFormadas = 0;

        public int LinhasFormadas { get => linhasFormadas; set => linhasFormadas = value; }

        public bool PodeInserir(Peca peca)
        {
            int cont = 0;

            if (peca.PosX > matriz.GetLength(0) - 3 || peca.PosY > matriz.GetLength(1) - 3 || peca.PosY < 0)
            {
                cont++;
            }
            else
            {
                for (int i = 0, posX = peca.PosX; i < peca.Forma.GetLength(0); i++, posX++)
                {
                    for (int j = 0, posY = peca.PosY; j < peca.Forma.GetLength(1); j++, posY++)
                    {
                        if (peca.Forma[i, j] == 1 && matriz[posX, posY] != 0)
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
        {
            
            for (int i = 0, posX = 0; i < peca.Forma.GetLength(0); i++, posX++) //peca[0,0] - matriz[0,3] ++ peca[0,1] - matriz[0,4]
                {
                    for (int j = 0, posY = 3; j < peca.Forma.GetLength(1); j++, posY++) // j = 3 = posy; j < 3 + 3 = pecay; j++
                    {
                        if (peca.Forma[i, j] == 1) //Forma[3, 3]
                        { 
                            matriz[posX, posY] = 1; //matriz[1,3] = 1
                        }
                    }
                }
        }

        public void Limpar(Peca peca) 
        {
            for (int posX = peca.PosX, i = 0; i < peca.Forma.GetLength(0); i++, posX++)
            {
                for (int posY = peca.PosY, j = 0; j < peca.Forma.GetLength(1); j++, posY++)
                {
                    if (peca.Forma[i, j] == 1)
                    {
                        matriz[posX, posY] = 0;
                    }
                }
            }
        }
        public void Atualizar(Peca peca) 
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

        public void VerificarLinhas(Peca peca) 
        {
            int cont = 0;
            int linhaFormada;
            

            for(int i = 0; i < matriz.GetLength(0); i++)
            {

                for(int j = 1; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i,j] == 1)
                    {
                        cont++;
                    }
                }
                if (cont >= 8)
                {
                    linhaFormada = i;
                    LinhasFormadas++;
                    int[,] matrizCopia = new int[20, 10];

                    for(int w = 0; w < matriz.GetLength(0); w++)
                    {
                        for(int h = 0; h < matriz.GetLength(1); h++)
                        {
                            matrizCopia[w, h] = matriz[w, h];
                        }
                    }

                    for (int k = 1; k < matriz.GetLength(1) - 1; k++)
                    {
                        matriz[linhaFormada, k] = 0;
                    }
                    for (int w = 1; w < matriz.GetLength(0) - 1; w++)
                    {
                        for (int h = 1; h < matriz.GetLength(1) - 1; h++)
                        {
                            matriz[w, h] = matrizCopia[w - 1, h];
                        }
                    }
                }
                cont = 0;
            }
            
           
        }
        public void Renderizar()
        {
            
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    if (matriz[i, j] == 0)
                    {
                        Console.Write(" .");
                    }
                    else if (matriz[i, j] == 2)
                    {
                        Console.Write(" O");
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
