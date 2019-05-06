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
            char[,] polybius = new char[5, 5] {
                {'a', 'b', 'c', 'd','e'},
                {'f', 'g', 'h', 'i','j'},
                {'k', 'l', 'm', 'n','o'},
                {'p', 'q', 'r', 's','t'},
                {'u', 'v', 'x', 'y','z'}};

            // E kerkojme nje fjali nga perdoruesi
            Console.Write("Fjalia per enkriptim: ");
            string fjalia = Console.ReadLine();

            int gjatesia = fjalia.Length;

            // Konvertojme fjaline e marre nga String ne Char-Array
            char[] fjaliaArray = fjalia.ToCharArray();

            int i, j, k = 0;
            string gjysmaPare = "", gjysmaFundit = "";

            while (k < gjatesia)
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        if (fjaliaArray[k] == polybius[i, j])
                        {
                            gjysmaPare += i;
                            gjysmaFundit += j;
                        }
                    }
                }
                k = k + 1;
            }

            string fjaliaString = gjysmaPare + gjysmaFundit;

            // Konvertojme prej String ne Char-Array
            char[] fjaliaCharArray = fjaliaString.ToCharArray();

            // Konvertojme prej Char-Array ne Int-Array
            int[] fjaliaIntArray = Array.ConvertAll(fjaliaCharArray, c => (int)Char.GetNumericValue(c));


            string fjaliaEnkriptune = "";
            int z = 0, m = 0, n = 1;
            while (z < gjatesia)
            {
                fjaliaEnkriptune += polybius[fjaliaIntArray[m], fjaliaIntArray[n]];
                m += 2;
                n += 2;
                z = z + 1;
            }
            Console.WriteLine("Fjalia e enkriptuar: " + fjaliaEnkriptune);
        }
    }
}
