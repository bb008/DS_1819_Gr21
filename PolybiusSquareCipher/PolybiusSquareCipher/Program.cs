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
            Console.Write("Numri i rreshtave te matrices: ");
            int rreshat = Convert.ToInt32(Console.ReadLine());
            Console.Write("Numri i kolonave te matrices: ");
            int kolonat = Convert.ToInt32(Console.ReadLine());

            Console.Write("Matrica pa qelesin: ");  // psh 6x6 abcdefghijklmnopqrstuvxyz0123456789 .
                                                    // ose 5x5 abcdefghijklmnopqrstuvxyz
            string matrica = Console.ReadLine();

            Console.Write("Qelsi: ");
            string qelesi = Console.ReadLine();

            qelesi += matrica;

            var matricaUnike = new HashSet<char>(qelesi);

            char[] qelesiArray = new char[rreshat * kolonat];

            int p = 0;
            foreach (char c in matricaUnike)
            {
                qelesiArray[p] = c;
                p++;
            }

            p = 0;
            char[,] polybius = new char[rreshat, kolonat];

            for (int i = 0; i < rreshat; i++)
            {
                for (int j = 0; j < kolonat; j++)
                {
                    polybius[i, j] = qelesiArray[p];
                    p++;
                }

            }

            // Enkriptimi

            Console.Write("Fjalia per enkriptim: ");
            string fjaliaPerEn = Console.ReadLine();

            int gjatesiaEn = fjaliaPerEn.Length;

            char[] fjaliaEnArray = fjaliaPerEn.ToCharArray();

            int k = 0;
            int[] gjysmaPare = new int[gjatesiaEn];
            int[] gjysmaFundit = new int[gjatesiaEn];

            while (k < gjatesiaEn)
            {
                for (int i = 0; i < rreshat; i++)
                {
                    for (int j = 0; j < kolonat; j++)
                    {
                        if (fjaliaEnArray[k] == polybius[i, j])
                        {
                            gjysmaPare[k] = i;
                            gjysmaFundit[k] = j;
                        }
                    }
                }
                k = k + 1;
            }

            int[] fjaliaPlote = gjysmaPare.Concat(gjysmaFundit).ToArray();

            string fjaliaEnkriptuar = "";
            int z = 0, m = 0, n = 1;
            while (z < gjatesiaEn)
            {
                fjaliaEnkriptuar += polybius[fjaliaPlote[m], fjaliaPlote[n]];
                m += 2;
                n += 2;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e enkriptuar: " + fjaliaEnkriptuar + ".");
            Console.WriteLine();

            // Dekriptimi

            Console.Write("Fjalia per dekriptim: ");
            string fjaliaPerDek = Console.ReadLine();

            int gjatesiaDek = fjaliaPerDek.Length;

            char[] fjaliaArray02 = fjaliaPerDek.ToCharArray();

            string fjaliaDekStr = "";
            k = 0;

            while (k < gjatesiaDek)
            {
                for (int i = 0; i < rreshat; i++)
                {
                    for (int j = 0; j < kolonat; j++)
                    {
                        if (fjaliaArray02[k] == polybius[i, j])
                        {
                            fjaliaDekStr = fjaliaDekStr + i + j;
                        }
                    }
                }
                k = k + 1;
            }

            char[] fjaliaDekCharArray = fjaliaDekStr.ToCharArray();

            int[] fjaliaDekIntArray = Array.ConvertAll(fjaliaDekCharArray, c => (int)Char.GetNumericValue(c));

            string fjaliaDekriptuar = "";
            m = 0;
            z = 0;
            n = gjatesiaDek;
            while (z < gjatesiaDek)
            {
                fjaliaDekriptuar += polybius[fjaliaDekIntArray[m], fjaliaDekIntArray[n]];
                m++;
                n++;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e dekriptuar: " + fjaliaDekriptuar);
        }
    }
}
