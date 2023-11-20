using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caGrafo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Grafo grafo = new Grafo();
            grafo.AdicionarCidade("Itumbiara", new Dictionary<string, int> { { "Tupaciguara", 55 }, { "Centralina", 20 } });
            grafo.AdicionarCidade("Tupaciguara", new Dictionary<string, int> { { "Monte Alegre de Minas", 44 }, { "Uberlandia", 60 } });
            grafo.AdicionarCidade("Centralina", new Dictionary<string, int> { { "Capinopolis", 40 }, { "Monte Alegre de Minas", 75 } });
            grafo.AdicionarCidade("Capinopolis", new Dictionary<string, int> { { "Ituiutaba", 30 } });
            grafo.AdicionarCidade("Ituiutaba", new Dictionary<string, int> { { "Monte Alegre de Minas", 85 }, { "Douradinhos", 90 } });
            grafo.AdicionarCidade("Douradinhos", new Dictionary<string, int> { { "Monte Alegre de Minas", 28 }, { "Uberlandia", 63 } });
            grafo.AdicionarCidade("Uberlandia", new Dictionary<string, int> { { "Monte Alegre de Minas", 60 }, { "Araguari", 30 }, { "Indianopolis", 45 }, { "Irai", 78 } });
            grafo.AdicionarCidade("Araguari", new Dictionary<string, int> { { "Cascalho Rico", 28 }, { "Estrela do Sul", 34 } });
            grafo.AdicionarCidade("Cascalho Rico", new Dictionary<string, int> { { "Grupiara", 32 } });
            grafo.AdicionarCidade("Grupiara", new Dictionary<string, int> { { "Estrela do Sul", 38 } });
            grafo.AdicionarCidade("Estrela do Sul", new Dictionary<string, int> { { "Irai", 27 } });
            grafo.AdicionarCidade("Irai", new Dictionary<string, int> { { "Sao Juliana", 28 } });
            grafo.AdicionarCidade("Sao Juliana", new Dictionary<string, int> { { "Indianopolis", 40 } });
            grafo.AdicionarCidade("Indianopolis", new Dictionary<string, int> { { "Uberlandia", 45 }, { "Sao Juliana", 45 } });
            grafo.AdicionarCidade("Monte Alegre de Minas", new Dictionary<string, int> { { "Uberlandia", 60 }, { "Tupaciguara", 44 }, { "Douradinhos", 28 }, { "Ituiutaba", 85 }, { "Centralina", 75 } });

            

            Console.Write("Informe a cidade de origem: ");
            string cidadeOrigem = Console.ReadLine();

            Console.Write("Informe a cidade de destino: ");
            string cidadeDestino = Console.ReadLine();

            Dictionary<string, string> anterior;
            Dictionary<string, int> distanciaMinima = grafo.Dijkstra(cidadeOrigem, out anterior);


            int menorCaminho = distanciaMinima[cidadeDestino];
            List<string> caminhoCidades = grafo.ObterCaminhoMinimo(cidadeOrigem, cidadeDestino, anterior);

            Console.Write("Caminho percorrido: ");
            for (int i = 0; i < caminhoCidades.Count; i++)
            {
                Console.Write(caminhoCidades[i]);
                if (i < caminhoCidades.Count - 1) //Count pega a quantidade de elementos na lista
                {
                    Console.Write(" -> ");
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Distância: {menorCaminho} km");

            Console.Read();
        }
    }
}
