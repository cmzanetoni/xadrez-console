using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    Peca peca = tabuleiro.getPeca(i, j);
                    if (peca != null) {
                        Console.Write(peca + " ");
                    }
                    else {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
