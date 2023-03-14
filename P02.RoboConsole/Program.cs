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
                    #region Menu e opção de sair;

                    Console.Clear();
                    Console.WriteLine("===============================");
                    Console.WriteLine("\nPerdido em Marte!\n");
                    Console.WriteLine("===============================");

                    Console.Write("\nDigite S para sair, ou qualquer outro botão para continuar:\n> ");

                    string op;
                    op = Console.ReadLine();

                    if (op == "s" || op == "S")
                    {
                         Console.WriteLine("\nSaindo...");
                         break;
                    }

                    #endregion

                    #region Entrada do valor da dimensão;

                    Console.Clear();

                    Console.Write("> Entre com o valor da dimensão da área que deseja explorar (inteiros separados por espaços para X e Y)\n: ");
                    string xy = Console.ReadLine();

                    #endregion

                    #region Separação da String em duas variáveis;

                    string[] dm = new string[2];

                    dm = xy.Split(" ");
                    int x = Convert.ToInt32(dm[0].Trim());
                    int y = Convert.ToInt32(dm[1].Trim());

                    #endregion
                   
                    Console.Write("\n> Certo... Agora que você já definiu o tamanho do mapa, vamos dar um local de origem ao nosso pequeno explorador.");
                    Console.Write("\n\n> Por favor, defina a posição que o seu robô irá começar, indicando sua direção:");
                    Console.Write("\nN = Norte;\nL = Leste;\nS = Sul;\nO = Oeste.");

                    for (int es = 0; es < 2; es++)
                    {
                         #region Entrada da posição inicial;

                         Console.Write($"\n\n> Entre com a posição inicial do '{es + 1}º Tupiniquim' (X Y Direção)\n: ");

                         string posi = Console.ReadLine();
                         posi = posi.ToUpper();
                         string[] dirp = new string[3];
                         dirp = posi.Split(" ");

                         #endregion

                         #region Conversão dos dados da Array, e atribuição em variáveis distintas;

                         int xx = Convert.ToInt32(dirp[0].Trim());
                         int yy = Convert.ToInt32(dirp[1].Trim());
                         char dxyi = Convert.ToChar(dirp[2].Trim());

                         #endregion

                         #region Verifica se os valores estão dentro dos parâmetros de dimensão;

                         if (xx > x || yy > y)
                         {
                              Console.Write("\n> Entre com valores válidos, dentro dos parâmetros criados.");
                              Console.Clear();
                              Console.Write("\n\n> Entre com a posição inicial do 'Tupiniquim I' (X Y Direção)\n: ");
                              posi = Console.ReadLine();
                         }

                         #endregion

                         #region Entrada das instruções;

                         Console.Write("\n> Perfeito. Está na hora de ensinar esse robô a andar.");
                         Console.Write("\n> Defina uma sequência de instruções para movimentar o robô (ex:mmemmdm):");
                         Console.Write("\nM = Mover;\nE = Virar 90º para a esquerda;\nD = Virar 90º para a direita.\n:");
                         string comm = Console.ReadLine();

                         comm = comm.ToUpper();


                         char[] com = comm.ToCharArray();

                         #endregion

                         #region Verificação de direção, e soma ou subtração da posição X e Y;

                         for (int i = 0; i < Convert.ToInt32(com.Length); i++)
                         {
                              if (com[i] == 'E' && dxyi == 'O')
                              {
                                   dxyi = 'S';
                                   Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                                   continue;
                              }
                              if (com[i] == 'D' && dxyi == 'O')
                              {
                                   dxyi = 'N';
                                   Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                                   continue;
                              }
                              if (com[i] == 'E' && dxyi == 'N')
                              {
                                   dxyi = 'O';
                                   Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                                   continue;
                              }
                              if (com[i] == 'D' && dxyi == 'N')
                              {
                                   dxyi = 'L';
                                   Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                                   continue;
                              }
                              if (com[i] == 'D' && dxyi == 'L')
                              {
                                   dxyi = 'S';
                                   Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                                   continue;
                              }
                              if (com[i] == 'E' && dxyi == 'L')
                              {
                                   dxyi = 'N';
                                   Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                                   continue;
                              }
                              if (com[i] == 'E' && dxyi == 'S')
                              {
                                   dxyi = 'L';
                                   Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                                   continue;
                              }
                              if (com[i] == 'D' && dxyi == 'S')
                              {
                                   dxyi = 'O';
                                   Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                                   continue;
                              }

                              else if (com[i] == 'M' && dxyi == 'O' && xx < x && xx > 0)
                              {
                                   xx--;
                                   Console.WriteLine("\n> Avante!");
                                   continue;
                              }

                              else if (com[i] == 'M' && dxyi == 'N' && yy < y && yy > 0)
                              {
                                   yy++;
                                   Console.WriteLine("\n> Avante!");
                                   continue;
                              }
                              else if (com[i] == 'M' && dxyi == 'L' && xx < x && xx > 0)
                              {
                                   xx++;
                                   Console.WriteLine("\n> Avante!");
                                   continue;
                              }
                              else if (com[i] == 'M' && dxyi == 'S' && yy < y && yy > 0)
                              {
                                   yy--;
                                   Console.WriteLine("\n> Avante!");
                                   continue;
                              }
                              else
                              {
                                   Console.WriteLine("\n> Chegou na borda de Marte!");
                                   continue;
                              }

                         }

                         #endregion

                         #region Impressão da posição e direção;

                         Console.WriteLine($"\n'O {es + 1}º Tupiniquim' está na posição {xx} {yy} {dxyi}!");
                         Console.ReadLine();

                         #endregion
                    }

               } while (true);
          }
     }
}
