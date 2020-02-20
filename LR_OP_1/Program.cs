using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LR_OP_1
{
    class Program
    {
        static string[,] ReadText()
        {
            string str = File.ReadAllText("premier_league1.csv");
            int c=0;
            // Spliting
            string[] wordSplit = str.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); 
            string temp;
            // figure out how many teams
            for (int i = 0; i < wordSplit.Length; i++) 
            {
                temp = wordSplit[i];
                if (Char.IsLetter(temp[0]))
                {
                    c++;
                }
            }
            int n = int.Parse(wordSplit[0]) + 1;
          string[,] tabl = new string[c , n];
            int counter = 1;
            // fill table
            for (int i = 0; i < c; i++) 
            {
                for (int j = 0; j < n; j++)
                {
                    tabl[i,j] = wordSplit[counter];
                    counter++;
                }  
            }
            return tabl;
        }

        static void Main(string[] args)
        {
            string[,] num = ReadText();
            Console.WriteLine("HelloWorld");
            Console.ReadLine();
        }
    }
}
