using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor) { }

        private bool existeInimigo(Posicao pos)
        {
            Peca? p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao pos = new Posicao(0, 0);

            if (cor == Cor.Branca)
            {
                // Anda 1 casa para frente
                pos.definirValores(posicao.Linha - 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos)) mat[pos.Linha, pos.Coluna] = true;

                // Anda 2 casa para frente
                pos.definirValores(posicao.Linha - 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) mat[pos.Linha, pos.Coluna] = true;

                // Captura inimigo da esquerda
                pos.definirValores(posicao.Linha - 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) mat[pos.Linha, pos.Coluna] = true;// Captura inimigo da esquerda

                // Captura inimigo da direita
                pos.definirValores(posicao.Linha - 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) mat[pos.Linha, pos.Coluna] = true;
            }
            else
            {
                // Anda 1 casa para frente
                pos.definirValores(posicao.Linha + 1, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos)) mat[pos.Linha, pos.Coluna] = true;

                // Anda 2 casa para frente
                pos.definirValores(posicao.Linha + 2, posicao.Coluna);
                if (tab.posicaoValida(pos) && livre(pos) && qteMovimentos == 0) mat[pos.Linha, pos.Coluna] = true;

                // Captura inimigo da esquerda
                pos.definirValores(posicao.Linha + 1, posicao.Coluna + 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) mat[pos.Linha, pos.Coluna] = true;// Captura inimigo da esquerda

                // Captura inimigo da direita
                pos.definirValores(posicao.Linha + 1, posicao.Coluna - 1);
                if (tab.posicaoValida(pos) && existeInimigo(pos)) mat[pos.Linha, pos.Coluna] = true;
            }




            return mat;
        }

        public override string ToString()
        {
            return "\u2659";
        }
    }
}
