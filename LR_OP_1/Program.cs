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
            int[,] ResultOfCurrentTeams = new int[c, int.Parse(wordSplit[0])];
            int[,] ResultOfOpponentTeams = new int[c, int.Parse(wordSplit[0])];

            for (int i = 0; i < c; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    temp = tabl[i, j];
                    if (Char.IsNumber(temp[0]))
                    {
                        ResultOfCurrentTeams[i, j-1] = temp[0] - '0'; 
                        ResultOfOpponentTeams[i,j-1] = temp[2] - '0';Console.Write(ResultOfOpponentTeams[i, j-1]+" ");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < c; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    temp = tabl[i, j];
                    if (Char.IsNumber(temp[0]))
                    {
                        
                    }
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
