﻿using System;
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
            char[,] polybius = new char[5, 5] {
                {'a', 'b', 'c', 'd','e'},
                {'f', 'g', 'h', 'i','j'},
                {'k', 'l', 'm', 'n','o'},
                {'p', 'q', 'r', 's','t'},
                {'u', 'v', 'x', 'y','z'}};

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

            string fjaliaEnkriptune = "";
            int z = 0, m = 0, n = 1;
            while (z < gjatesia)
            {
                fjaliaEnkriptune += polybius[teresia[m], teresia[n]];
                m += 2;
                n += 2;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e enkriptuar: " + fjaliaEnkriptune);
            Console.WriteLine();

            // Dekriptimi

            Console.Write("Fjalia per dekriptim: ");
            string fjaliaPerDekriptim = Console.ReadLine();
            int gjatesia02 = fjaliaPerDekriptim.Length;
            char[] fjaliaArray02 = fjaliaPerDekriptim.ToCharArray();
            string fjaliaStr = "";
            k = 0;
            while (k < gjatesia)
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

            string fjaliaDekriptune = "";
            m = 0;
            z = 0;
            n = gjatesia02;
            while (z < gjatesia02)
            {
                fjaliaDekriptune += polybius[fjaliaIntArray[m], fjaliaIntArray[n]];
                m++;
                n++;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e dekriptuar: " + fjaliaDekriptune);
        }
    }
}
