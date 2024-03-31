using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define o tipo de codificação de texto do console para UTF-8
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                // Escreve o título do jogo de xadrez
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n     Xadrez do Alex!\n");

                // Inicia a partida de xadrez
                PartidaXadrez partida = new PartidaXadrez();

                // Repete enquando a partida não terminar
                while (!partida.terminada)
                {
                    // Limpa a tela
                    Console.Clear();

                    // Desenha na tela
                    Tela.imprimirTabuleiro(partida.tab);

                    // Solicita a origem
                    Console.Write("Informe a origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();

                    // Solicita o destino
                    Console.Write("Informe o destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    // Executa o movimento
                    partida.executarMovimento(origem, destino);
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}