using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
                tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
                tabuleiro.setPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));
                tabuleiro.setPeca(new Rei(tabuleiro, Cor.Branca), new Posicao(5, 5));

                Tela.imprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException ex) {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
