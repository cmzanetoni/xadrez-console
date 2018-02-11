using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez_console {
    class Tela {
        public static void imprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    Peca peca = tabuleiro.getPeca(i, j);
                    if (peca != null) {
                        imprimirPeca(peca);
                        Console.Write(" ");
                    }
                    else {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void imprimirPeca(Peca peca) {
            if (peca.cor == Cor.Branca) {
                Console.Write(peca);
            }
            else {
                ConsoleColor corOriginal = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = corOriginal;
            }
        }
    }
}
