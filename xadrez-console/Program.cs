using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);
            Tela.imprimirTabuleiro(tabuleiro);
            Console.ReadLine();
        }
    }
}
