using System;
using System.Collections.Generic;
using System.Linq;
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



        //public bool PodeInserir (int [,] peca) { }   
        public void InserirPeca(Peca peca) { }
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
        public void Renderizar() { }
    }
}
