using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez_console.xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.setPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.setPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2, 4));

            Tela.imprimirTabuleiro(tabuleiro);
            Console.ReadLine();
        }
    }
}
