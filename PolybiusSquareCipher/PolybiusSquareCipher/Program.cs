using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolybiusSquareCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            // Qelesi
            Console.Write("Qelsi: ");
            string qelesi = Console.ReadLine();

            qelesi += "abcdefghiklmnopqrstuvwxyz";

            var qelesiUnik = new HashSet<char>(qelesi);

            char[] qelesiArray = new char[25];

            int p = 0;
            foreach (char c in qelesiUnik)
            {
                qelesiArray[p] = c;
                p++;
            }

            p = 0;
            char[,] polybius = new char[5, 5];
            for (int o = 0; o < 5; o++)
            {
                for (int s = 0; s < 5; s++)
                {
                    polybius[o, s] = qelesiArray[p];
                    p++;
                }

            }

            // Enkriptimi

            Console.Write("Fjalia per enkriptim: ");
            string fjalia = Console.ReadLine();

            int gjatesia = fjalia.Length;

            char[] fjaliaArray = fjalia.ToCharArray();

            int i, j, k = 0;
            int[] gjysmaPare = new int[gjatesia];
            int[] gjysmaFundit = new int[gjatesia];

            while (k < gjatesia)
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        if (fjaliaArray[k] == polybius[i, j])
                        {
                            gjysmaPare[k] = i;
                            gjysmaFundit[k] = j;
                        }
                    }
                }
                k = k + 1;
            }

            int[] teresia = gjysmaPare.Concat(gjysmaFundit).ToArray();

            string fjaliaEnkriptuar = "";
            int z = 0, m = 0, n = 1;
            while (z < gjatesia)
            {
                fjaliaEnkriptuar += polybius[teresia[m], teresia[n]];
                m += 2;
                n += 2;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e enkriptuar: " + fjaliaEnkriptuar);
            Console.WriteLine();

            // Dekriptimi

            Console.Write("Fjalia per dekriptim: ");
            string fjaliaPerDekriptim = Console.ReadLine();
            int gjatesia02 = fjaliaPerDekriptim.Length;
            char[] fjaliaArray02 = fjaliaPerDekriptim.ToCharArray();
            string fjaliaStr = "";
            k = 0;
            while (k < gjatesia02)
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        if (fjaliaArray02[k] == polybius[i, j])
                        {
                            fjaliaStr = fjaliaStr + i + j;
                        }
                    }
                }
                k = k + 1;
            }

            char[] fjaliaCharArray = fjaliaStr.ToCharArray();

            int[] fjaliaIntArray = Array.ConvertAll(fjaliaCharArray, c => (int)Char.GetNumericValue(c));

            string fjaliaDekriptuar = "";
            m = 0;
            z = 0;
            n = gjatesia02;
            while (z < gjatesia02)
            {
                fjaliaDekriptuar += polybius[fjaliaIntArray[m], fjaliaIntArray[n]];
                m++;
                n++;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e dekriptuar: " + fjaliaDekriptuar);
        }
    }
}
