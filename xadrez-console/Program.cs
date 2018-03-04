﻿using System;
using System.Collections.Generic;
using tabuleiro;
using xadrez;

namespace xadrez_console {
    class Program {
        static void Main(string[] args) {
            try {
                PartidaDeXadrez partidaDeXadrez = new PartidaDeXadrez();                

                while (!partidaDeXadrez.terminada) {
                    try {
                        Console.Clear();
                        Tela.imprimirPartida(partidaDeXadrez);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partidaDeXadrez.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partidaDeXadrez.tabuleiro.getPeca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.imprimirTabuleiro(partidaDeXadrez.tabuleiro, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partidaDeXadrez.validarPosicaoDeDestino(origem, destino);                        

                        partidaDeXadrez.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException ex) {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }                    
                }
                Console.Clear();
                Tela.imprimirPartida(partidaDeXadrez);
            }
            catch (TabuleiroException ex) {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
