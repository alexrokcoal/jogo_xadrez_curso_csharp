using tabuleiro;


namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            bool darkBackground = false;

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
                        Console.Write("- ");
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

            Console.WriteLine("     a b c d e f g h\n\n");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.Branca)
            {
                Console.Write(peca);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }

        }
    }
}
