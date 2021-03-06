﻿using System.Collections.Generic;
using tabuleiro;

namespace xadrez {
    class PartidaDeXadrez {
        public Tabuleiro tabuleiro { get; private set; } 
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;
        public bool xeque { get; private set; }

        public PartidaDeXadrez() {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecasIniciais();
        }

        public Peca executaMovimento(Posicao origem, Posicao destino) {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCaptura = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if (pecaCaptura != null) {
                capturadas.Add(pecaCaptura);
            }

            return pecaCaptura;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada) {
            Peca p = tabuleiro.retirarPeca(destino);
            p.decrementarQtdMovimentos();
            if (pecaCapturada != null) {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(p, origem);
        }

        private void mudaJogador() {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            }
            else {
                jogadorAtual = Cor.Branca;
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino) {
            Peca pecaCapturada = executaMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual)) {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em xeque!");
               
            }

            xeque = estaEmXeque(adversaria(jogadorAtual));

            if (testeXequeMate(adversaria(jogadorAtual))) {
                terminada = true;
            }
            else {
                turno++;
                mudaJogador();
            }
        }

        public bool testeXequeMate(Cor cor) {
            if(!estaEmXeque(cor)) {
                return false;
            }

            foreach (Peca x in pecasEmJogo(cor)) {
                bool[,] mat = x.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++) {
                    for (int j = 0; j < tabuleiro.colunas; j++) {
                        if (mat[i, j]) {
                            Posicao origem = x.posicao; 
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque) {
                                return false;
                            }

                        }
                    }
                }
            }

            return true;
        }

        public void validarPosicaoDeOrigem(Posicao pos) {
            if (tabuleiro.getPeca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posiçaõ de origem!");
            }
            if (jogadorAtual != tabuleiro.getPeca(pos).cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!tabuleiro.getPeca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino) {
            if (!tabuleiro.getPeca(origem).podeMoverPara(destino)) {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }

            return aux;
        }

        private Cor adversaria(Cor cor) {
            if (cor == Cor.Branca) {
                return Cor.Preta;
            }
            else {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor) {
            foreach (Peca x in pecasEmJogo(cor)) {
                if (x is Rei) {
                    return x;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor) {
            Peca R = rei(cor);
            if (R == null) {
                throw new TabuleiroException("Não existe rei da cor " + cor + "no tabuleiro!");
            }

            foreach(Peca x in pecasEmJogo(adversaria(cor))) {
                bool[,] mat = x.movimentosPossiveis();
                if (mat[R.posicao.linha, R.posicao.coluna]) {
                    return true;
                }
            }

            return false;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in pecas) {
                if (x.cor == cor) {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));

            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca) {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca);
        }

        private void colocarPecasIniciais() {
            colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 7, new Torre(tabuleiro, Cor.Branca));

            colocarNovaPeca('a', 8, new Rei(tabuleiro, Cor.Preta));
            colocarNovaPeca('b', 8, new Torre(tabuleiro, Cor.Preta));

            //colocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preta));
            //colocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));

            //colocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
            //colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));
            //colocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branca));
        }
    }
}
