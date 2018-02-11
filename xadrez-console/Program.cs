using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            PosicaoXadrez p = new PosicaoXadrez('A', 1);
            Console.WriteLine(p);
            Console.WriteLine(p.toPosicao());

            try {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
                tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
                tabuleiro.setPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));

                Tela.imprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException ex) {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
