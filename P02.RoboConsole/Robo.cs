using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.RoboConsole
{
     internal class Robo
     {
          public string[] dimensaoEspacial = new string[1];

          public string[] posicaoEspacial = new string[2];
       
          public string opcao, valorDimensao, posicaoInicial, comandos;

          public char[] comandosArmazenados = new char[50];

          public int comprimentoX, alturaY, posicaoInicialX, posicaoInicialY;
          char direcao;

          public string PegarValores(string mensagem, string status)
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

          public bool PosicaoInvalida()
          {
               return
                    posicaoInicialX > comprimentoX ||
                    posicaoInicialY > alturaY ||
                    direcao != 'N' &&
                    direcao != 'S' &&
                    direcao != 'L' &&
                    direcao != 'O';
          }

          public void ApresentarMensagem(string mensagem, string tipo)
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

          public void VerificaDirecao()
          {
               for (int i = 0; i < Convert.ToInt32(comandosArmazenados.Length); i++)
               {
                    if (comandosArmazenados[i] == 'E' && direcao == 'O')
                    {
                         direcao = 'S';
                         Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && direcao == 'O')
                    {
                         direcao = 'N';
                         Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && direcao == 'N')
                    {
                         direcao = 'O';
                         Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && direcao == 'N')
                    {
                         direcao = 'L';
                         Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && direcao == 'L')
                    {
                         direcao = 'S';
                         Console.WriteLine("\n> Câmeras apontadas para o Sul!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && direcao == 'L')
                    {
                         direcao = 'N';
                         Console.WriteLine("\n> Câmeras apontadas para o Norte!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'E' && direcao == 'S')
                    {
                         direcao = 'L';
                         Console.WriteLine("\n> Câmeras apontadas para o Leste!");
                         continue;
                    }
                    if (comandosArmazenados[i] == 'D' && direcao == 'S')
                    {
                         direcao = 'O';
                         Console.WriteLine("\n> Câmeras apontadas para o Oeste!");
                         continue;
                    }

                    else if (comandosArmazenados[i] == 'M' && direcao == 'O' && posicaoInicialX > 0)
                    {
                         posicaoInicialX--;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }

                    else if (comandosArmazenados[i] == 'M' && direcao == 'N' && posicaoInicialY < alturaY)
                    {
                         posicaoInicialY++;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }
                    else if (comandosArmazenados[i] == 'M' && direcao == 'L' && posicaoInicialX < comprimentoX)
                    {
                         posicaoInicialX++;
                         Console.WriteLine("\n> Avante!");
                         continue;
                    }
                    else if (comandosArmazenados[i] == 'M' && direcao == 'S' && posicaoInicialY > 0)
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

          public void PegarPosicaoInicial(int robos)
          {
               posicaoInicial = PegarValores($"> Entre com a posição inicial do '{robos + 1}º Tupiniquim' (X Y Direção)\n: ", "nada");
               posicaoEspacial = posicaoInicial.Split(" ");

               posicaoInicialX = Convert.ToInt32(posicaoEspacial[0].Trim());
               posicaoInicialY = Convert.ToInt32(posicaoEspacial[1].Trim());
               direcao = Convert.ToChar(posicaoEspacial[2].Trim());
          }        

          public void GerarRobo()
          {
               for (int robos = 0; robos < 2; robos++)
               {
                    if (robos == 1)
                    {
                         Console.Clear();
                    }

                    PegarPosicaoInicial(robos);

                    while (PosicaoInvalida())
                    {
                         ApresentarMensagem("\n> Entre com valores válidos, dentro dos parâmetros criados.", "ERRO");
                         Console.Clear();
                         PegarPosicaoInicial(robos);
                    }

                    Console.Write("\n> Perfeito. Está na hora de ensinar esse robô a andar.");
                    Console.Write("\n> Defina uma sequência de instruções para movimentar o robô (ex:mmemmdm):");
                    comandos = PegarValores("\nM = Mover;\nE = Virar 90º para a esquerda;\nD = Virar 90º para a direita.\n:", "nada");
                    comandos = comandos.ToUpper();

                    comandosArmazenados = comandos.ToCharArray();

                    VerificaDirecao();

                    ApresentarMensagem($"\n'O {robos + 1}º Tupiniquim' está na posição {posicaoInicialX} {posicaoInicialY} {direcao}!", "SUCESSO");
               }
          }
     }
}
