using System;
namespace MatrizGrafo
{
    class Program
    {
        static void imprimirMatriz(int[,] matriz)
        {
            int tamanho = matriz.GetLength(0);
            for (int i = 0; i < tamanho; i++)
            {
                for (int j = 0; j < tamanho; j++)
                {
                    System.Console.Write(matriz[i, j] + " ");
                }
                System.Console.WriteLine();
            }
        }

        static int menu()
        {
            Console.WriteLine("Menu de Opções");
            Console.WriteLine("1 - Adicionar Aresta");
            Console.WriteLine("2 - Remover Aresta");
            Console.WriteLine("3 - Mostrar Matriz");
            Console.WriteLine("4 - Verificar Propriedades");
            Console.WriteLine("5 - Matriz R infinito");
            Console.WriteLine("6 - Matriz Conexividade");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            int opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        static void Main(string[] args)
        {
            Grafo meuGrafo = new Grafo(10);
            meuGrafo.carregarMatrizDeArquivo("Agabo.txt");
            int opcao=0;
            do
            {
               opcao = menu();
                switch (opcao)
                {
                    case 1:
                        System.Console.Write("Digite a origem: ");
                        int origem = int.Parse(System.Console.ReadLine());
                        System.Console.Write("Digite o destino");
                        int destino = int.Parse(System.Console.ReadLine());
                        meuGrafo.adicionarAresta(origem,destino);
                        break;
                    case 2:
                        Console.Write("Digite a origem: ");
                        origem = int.Parse(Console.ReadLine());
                        Console.Write("Digite o destino: ");
                        destino = int.Parse(Console.ReadLine());
                        meuGrafo.removerAresta(origem,destino);
                        break;
                    case 3:
                        meuGrafo.mostrarMatriz();
                        break;
                    case 4:
                        if (meuGrafo.eReflexiva())
                            Console.WriteLine("O grafo é reflexivo. ");
                        else
                            Console.WriteLine("O grafo não é reflexivo. ");

                        if (meuGrafo.eSimetrica())
                            Console.WriteLine("O grafo é simetrico. ");
                        else
                            Console.WriteLine("O grafo não é simetrico. ");

                        break;
                    case 5:
                        int[,] matrizRInfinito = meuGrafo.obterRInfinito();
                        Console.WriteLine("Matriz R Infinito: ");
                        imprimirMatriz(matrizRInfinito);
                        break;
                    case 6:
                        int[,] matrizConexividade = meuGrafo.obterMatrizConexividade();
                        Console.WriteLine("Matriz de Conexividade: ");
                        imprimirMatriz(matrizConexividade);
                        break;
                    case 0:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }while (opcao != 0);
        }
    }
}
