﻿using tabuleiro;
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

        public static void imprimirPartida(PartidaXadrez partida)
        {
            imprimirTabuleiro(partida.tab, null);

            imprimirPecasCapturadas(partida);

            // Apresenta informações na tela
            Console.WriteLine("Turno: " + partida.turno);

            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
                if (partida.xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.jogadorAtual);
            }
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

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
        }

        public static void imprimirPecasCapturadas(PartidaXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");

            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));

            Console.WriteLine();

            Console.Write("Pretas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));

            Console.WriteLine();
        }
    }
}
