using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Posicao posicao = new Posicao(2, 3);

            Console.WriteLine(posicao);
            Console.ReadLine();
        }
    }
}
