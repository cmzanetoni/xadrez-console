namespace tabuleiro {
    abstract class Peca {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentados { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.posicao = null;
            this.cor = cor;
            this.tabuleiro = tabuleiro;
            qtdMovimentados = 0;
        }

        public void incrementarQtdMovimentos() {
            qtdMovimentados++;
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
