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

                // Inicia a partida de xadrez
                PartidaXadrez partida = new PartidaXadrez();

                // Repete enquando a partida não terminar
                while (!partida.terminada)
                {
                    try
                    {
                        // Desenha na tela
                        Console.Clear();
                        Tela.imprimeTitulo();

                        Tela.imprimirPartida(partida);

                        // Solicita e valida a origem
                        Console.Write("\nInforme a origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoOrigem(origem);

                        // Obtém as os movimentos possíveis
                        bool[,] movimentosPossiveis = partida.tab.peca(origem).movimentosPossiveis();

                        // Desenha na tela
                        Console.Clear();
                        Tela.imprimeTitulo();
                        Tela.imprimirTabuleiro(partida.tab, movimentosPossiveis);

                        // Solicita e valida o destino
                        Console.Write("Informe o destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDestino(origem, destino);

                        // Executa o movimento
                        partida.realizaJogada(origem, destino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partida);

            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}