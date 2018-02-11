using tabuleiro;

namespace xadrez {
    class Torre : Peca {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor) {
        }

        public override string ToString() {
            return "T";
        }

        private bool podeMover(Posicao pos) {
            Peca peca = tabuleiro.getPeca(pos);
            return peca == null || peca.cor != cor;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }


            //baixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            //direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && podeMover(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.getPeca(pos) != null && tabuleiro.getPeca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }
    }
}
