using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Serialization.Formatters;

namespace Conversioni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] DP = new int[4];
            for (int i = 0; i < DP.Length; i++)
            {
                Console.WriteLine($"Inserisci la {i+1} cifra");
                DP[i] = Convert.ToInt32(Console.ReadLine());
            }

            bool[] bn = ConvertDpToBin(DP);

            for (int i = 0; i < bn.Length; i++)
            {
                Console.Write(Convert.ToInt32(bn[i]));
            }
            Console.WriteLine();
            Console.WriteLine(ConvertDPToInt(DP));

            Console.WriteLine();
            Console.ReadLine();
        }

        static bool[] ConvertDpToBin(int[] dp)  // 1
        {
            bool[] bn = new bool[32];
            int indice = bn.Length - 1;

            for(int i = 0; i < dp.Length; i++)
            {
                int num = dp[i];

                for(int j = 0; j < 8; j++)//8 sono i bit che rappresentano una cifra in decimale
                {
                    bn[indice] = num % 2 == 1;//quando bn[indice] == 1 cambia false nell'array di bool e mette true quindi 1; il false è settato a 0
                    num = num / 2;
                    indice--;
                }
            }
            return bn;
        }

        static int ConvertDPToInt(int[] dp)
        {
            int dec = 0;
            int y = 3;

            for(int i = 0; i < dp.Length; i++)//fa la moltiplicazione con dec = dp[i] che parte da i = 0 che moltiplica (int) di math.pow(ed eleva alla y 256)
            {
                dec += dp[i] * (int)Math.Pow(256, y--);
            }

            return dec;
        }


    }
}
