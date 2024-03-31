using tabuleiro;
using xadrez;


namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
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

                    //if (i % 2 == 0) darkBackground = !darkBackground;

                    if (darkBackground)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }

                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {

                        imprimirPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }

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

        public static void imprimirPeca(Peca peca)
        {
            ConsoleColor aux = Console.ForegroundColor;

            if (peca.cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
            }

            Console.Write(peca);
            Console.ForegroundColor = aux;

        }
    }
}
