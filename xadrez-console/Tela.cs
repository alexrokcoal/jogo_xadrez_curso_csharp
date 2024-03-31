using tabuleiro;
using xadrez;


namespace xadrez_console
{
    class Tela
    {
        public static void imprimeTitulo()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n     Xadrez do Alex!\n");
        }

        public static void imprimirTabuleiro(Tabuleiro tab, bool[,]? posicoesPossiveis)
        {
            bool darkBackground = false;

            Console.CursorSize = 100;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   " + (8 - i) + " ");

                darkBackground = !darkBackground;

                for (int j = 0; j < tab.colunas; j++)
                {
                    darkBackground = !darkBackground;

                    if (posicoesPossiveis != null && posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = darkBackground ? ConsoleColor.DarkYellow : ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.BackgroundColor = darkBackground ? ConsoleColor.DarkBlue : ConsoleColor.Blue;
                    }

                    imprimirPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }

            Console.BackgroundColor = ConsoleColor.Black;

            Console.WriteLine("     a b c d e f g h\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine()!;
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void imprimirPeca(Peca? peca)
        {
            if (peca == null)
            {
                Console.Write("  ");
                return;
            }

            ConsoleColor aux = Console.ForegroundColor;

            if (peca.cor == Cor.Branca) Console.ForegroundColor = ConsoleColor.White;
            else Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(peca + " ");
            Console.ForegroundColor = aux;
        }
    }
}
