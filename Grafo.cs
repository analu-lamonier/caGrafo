using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caGrafo
{
    internal class Grafo
    {
        private Dictionary<string, Dictionary<string, int>> grafo = new Dictionary<string, Dictionary<string, int>>();

        public void AdicionarCidade(string cidade, Dictionary<string, int> vizinhos)
        {
            grafo[cidade] = vizinhos;
        }
        

        public Dictionary<string, int> Dijkstra(string cidadeInicial, out Dictionary<string, string> anterior)
        {
            Dictionary<string, int> distanciaMinima = new Dictionary<string, int>();
            anterior = new Dictionary<string, string>();
            HashSet<string> visitados = new HashSet<string>();

            foreach (var cidade in grafo.Keys)
            {
                distanciaMinima[cidade] = int.MaxValue;
            }

            distanciaMinima[cidadeInicial] = 0;

            while (true)
            {
                string cidadeAtual = EncontrarCidadeMenorDistancia(distanciaMinima, visitados);
                if (cidadeAtual == null)
                {
                    break;
                }

                visitados.Add(cidadeAtual);

                foreach (var vizinho in grafo[cidadeAtual])
                {
                    if (!visitados.Contains(vizinho.Key))
                    {
                        int novaDistancia = distanciaMinima[cidadeAtual] + vizinho.Value;

                        if (!distanciaMinima.ContainsKey(vizinho.Key) || novaDistancia < distanciaMinima[vizinho.Key])
                        {
                            distanciaMinima[vizinho.Key] = novaDistancia;
                            anterior[vizinho.Key] = cidadeAtual;
                        }
                    }
                }
            }

            return distanciaMinima;
        }

        private string EncontrarCidadeMenorDistancia(Dictionary<string, int> distanciaMinima, HashSet<string> visitados)
        {
            int menorDistancia = int.MaxValue;
            string cidadeMenorDistancia = null;

            foreach (var cidade in distanciaMinima)
            {
                if (cidade.Value < menorDistancia && !visitados.Contains(cidade.Key))
                {
                    menorDistancia = cidade.Value;
                    cidadeMenorDistancia = cidade.Key;
                }
            }

            return cidadeMenorDistancia;
        }

        public List<string> ObterCaminhoMinimo(string cidadeInicial, string cidadeFinal, Dictionary<string, string> anterior)
        {
            List<string> caminho = new List<string>();
            string cidadeAtual = cidadeFinal;

            while (cidadeAtual != cidadeInicial)
            {
                caminho.Insert(0, cidadeAtual);
                if (!anterior.ContainsKey(cidadeAtual))
                {
                    // Não há caminho possível
                    return null;
                }
                cidadeAtual = anterior[cidadeAtual];
            }

            caminho.Insert(0, cidadeInicial);

            return caminho;
        }
    }
}
