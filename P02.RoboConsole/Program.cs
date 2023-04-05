using System;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace P02.RoboConsole
{
     internal class Program
     {
          static void Main(string[] args)
          {
               Robo robo1 = new Robo();

               do
               {
                    string opcao = GerarMenu();

                    if (opcao == "S")
                    {
                         Console.WriteLine("\nSaindo...");
                         Environment.Exit(0);
                    }

                    robo1.valorDimensao = robo1.PegarValores("> Entre com o valor da dimensão da área que deseja explorar (inteiros separados por espaços para X e Y)\n: ", "limpeza");

                    robo1.dimensaoEspacial = robo1.valorDimensao.Split(" ");

                    robo1.comprimentoX = Convert.ToInt32(robo1.dimensaoEspacial[0].Trim());
                    robo1.alturaY = Convert.ToInt32(robo1.dimensaoEspacial[1].Trim());

                    Console.Write("\n> Certo... Agora que você já definiu o tamanho do mapa, vamos dar um local de origem ao nosso pequeno explorador.");
                    Console.Write("\n\n> Por favor, defina a posição que o seu robô irá começar, indicando sua direção:");
                    Console.Write("\nN = Norte;\nL = Leste;\nS = Sul;\nO = Oeste.\n\n");

                    robo1.GerarRobo();

               } while (true);
          }
          private static string GerarMenu()
          {
               Console.Clear();
               Console.WriteLine("===============================");
               Console.WriteLine("\nPerdido em Marte!\n");
               Console.WriteLine("===============================");

               Console.Write("\nDigite S para sair, ou qualquer outro botão para continuar:\n> ");

               string opcao = Console.ReadLine().ToUpper();
               return opcao;
          }

     }
}
