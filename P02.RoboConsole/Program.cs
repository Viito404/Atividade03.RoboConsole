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
               do
               {
                    string opcao = GerarMenu();

                    if (opcao == "s" || opcao == "S")
                    {
                         Console.WriteLine("\nSaindo...");
                         break;
                    }

                    string valorDimensao = PegarValores("> Entre com o valor da dimensão da área que deseja explorar (inteiros separados por espaços para X e Y)\n: ", "limpeza");

                    dimensaoEspacial = valorDimensao.Split(" ");

                    int comprimentoX = Convert.ToInt32(dimensaoEspacial[0].Trim());
                    int alturaY = Convert.ToInt32(dimensaoEspacial[1].Trim());

                    Console.Write("\n> Certo... Agora que você já definiu o tamanho do mapa, vamos dar um local de origem ao nosso pequeno explorador.");
                    Console.Write("\n\n> Por favor, defina a posição que o seu robô irá começar, indicando sua direção:");
                    Console.Write("\nN = Norte;\nL = Leste;\nS = Sul;\nO = Oeste.\n\n");

                    for (int robos = 0; robos < 2; robos++)
                    {
                         if (robos == 1)
                         {
                              Console.Clear();
                         }

                         string posicaoInicial;
                         int posicaoInicialX, posicaoInicialY;
                         char direcao;

                         PegarPosicaoInicial(robos, out posicaoInicial, out posicaoInicialX, out posicaoInicialY, out direcao);

                         while (PosicaoInvalida(posicaoInicialX, comprimentoX, posicaoInicialY, alturaY, direcao))
                         {
                              ApresentarMensagem("\n> Entre com valores válidos, dentro dos parâmetros criados.", "ERRO");
                              Console.Clear();
                              PegarPosicaoInicial(robos, out posicaoInicial, out posicaoInicialX, out posicaoInicialY, out direcao);
                         }

                         Console.Write("\n> Perfeito. Está na hora de ensinar esse robô a andar.");
                         Console.Write("\n> Defina uma sequência de instruções para movimentar o robô (ex:mmemmdm):");
                         string comandos = PegarValores("\nM = Mover;\nE = Virar 90º para a esquerda;\nD = Virar 90º para a direita.\n:", "nada");
                         comandos = comandos.ToUpper();

                         char[] comandosArmazenados = comandos.ToCharArray();

                         VerificaDirecao(comprimentoX, alturaY, ref posicaoInicialX, ref posicaoInicialY, ref direcao, comandosArmazenados);

                         ApresentarMensagem($"\n'O {robos + 1}º Tupiniquim' está na posição {posicaoInicialX} {posicaoInicialY} {direcao}!", "SUCESSO");
                    }

               } while (true);
          }

          #region Variáveis Globais;

          static string[] dimensaoEspacial = new string[1];

          static string[] posicaoEspacial = new string[2];

          #endregion

          #region Funções do Robo;

          static string GerarMenu()
          {
               Console.Clear();
               Console.WriteLine("===============================");
               Console.WriteLine("\nPerdido em Marte!\n");
               Console.WriteLine("===============================");

               Console.Write("\nDigite S para sair, ou qualquer outro botão para continuar:\n> ");

               string opcao = Console.ReadLine();
               return opcao;
          }

          static string PegarValores(string mensagem, string status)
          {
               if (status == "limpeza")
               {
                    Console.Clear();
               }


               Console.Write(mensagem);
               string valor = Console.ReadLine();
               valor = valor.ToUpper();
               return valor;
          }

          static bool PosicaoInvalida(int posicaoInicialX, int comprimentoX, int posicaoInicialY, int alturaY, char direcao)
          {
               return
                    posicaoInicialX > comprimentoX ||
                    posicaoInicialY > alturaY ||
                    direcao != 'N' &&
                    direcao != 'S' &&
                    direcao != 'L' &&
                    direcao != 'O';
          }

          static void ApresentarMensagem(string mensagem, string tipo)
          {
               if (tipo == "ERRO")
               {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
                    Console.ResetColor();
               }
               else
               {
                    Console.WriteLine(mensagem);
                    Console.ReadLine();
               }
          }

          static void VerificaDirecao(int comprimentoX, int alturaY, ref int posicaoInicialX, ref int posicaoInicialY, ref char Direcao, char[] comandosArmazenados)
          {
               for (int i = 0; i < Convert.ToInt32(comandosArmazenados.Length); i++)
               {
                    if (comandosArmazenados[i] == 'E' && Direcao == 'O')
                    {
                         Direcao = 'S';
                         Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && Direcao == 'O')
                    {
                         Direcao = 'N';
                         Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && Direcao == 'N')
                    {
                         Direcao = 'O';
                         Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && Direcao == 'N')
                    {
                         Direcao = 'L';
                         Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && Direcao == 'L')
                    {
                         Direcao = 'S';
                         Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && Direcao == 'L')
                    {
                         Direcao = 'N';
                         Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && Direcao == 'S')
                    {
                         Direcao = 'L';
                         Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && Direcao == 'S')
                    {
                         Direcao = 'O';
                         Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                         continue;
                    }

                    else if (comandosArmazenados[i] == 'M' && Direcao == 'O' && posicaoInicialX > 0)
                    {
                         posicaoInicialX--;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }

                    else if (comandosArmazenados[i] == 'M' && Direcao == 'N' && posicaoInicialY < alturaY)
                    {
                         posicaoInicialY++;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }
                    else if (comandosArmazenados[i] == 'M' && Direcao == 'L' && posicaoInicialX < comprimentoX)
                    {
                         posicaoInicialX++;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }
                    else if (comandosArmazenados[i] == 'M' && Direcao == 'S' && posicaoInicialY > 0)
                    {
                         posicaoInicialY--;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }
                    else
                    {
                         Console.WriteLine("\n> Chegou na borda de Marte!");
                         continue;
                    }

               }
          }

          static void PegarPosicaoInicial(int robos, out string posicaoInicial, out int posicaoInicialX, out int posicaoInicialY, out char Direcao)
          {
               posicaoInicial = PegarValores($"> Entre com a posição inicial do '{robos + 1}º Tupiniquim' (X Y Direção)\n: ", "nada");
               posicaoEspacial = posicaoInicial.Split(" ");

               posicaoInicialX = Convert.ToInt32(posicaoEspacial[0].Trim());
               posicaoInicialY = Convert.ToInt32(posicaoEspacial[1].Trim());
               Direcao = Convert.ToChar(posicaoEspacial[2].Trim());
          }

          #endregion

     }
}
