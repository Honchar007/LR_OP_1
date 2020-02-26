using System;
using System.IO;
using System.Text.RegularExpressions;

namespace LR_OP_1
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadText();

            //DivideOnTwoTables(tabl, tabl.GetLowerBound(0), tabl.Length / tabl.GetLowerBound(0));
            Console.WriteLine("HelloWorld");
            Console.ReadLine();
        }
        static void ReadText()
        {
            string str = File.ReadAllText("premier_league1.csv");
            int c = 0;
            // Splitting
            string[] wordSplit = str.Split(new char[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string temp;
            // figure out how many teams we have
            for (int i = 0; i < wordSplit.Length; i++)
            {
                temp = wordSplit[i];
                if (Char.IsLetter(temp[0]))
                {
                    c++;
                }
            }
            int n = int.Parse(wordSplit[0]) + 1;
            string[,] tabl = new string[c, n];
            int counter = 1;
            // fill table
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    tabl[i, j] = wordSplit[counter];
                    counter++;
                }
            }
            DivideOnTwoTables(tabl, c, n);
        }
        static void DivideOnTwoTables(string[,] tabl, int teamsN, int matchN)
        {
            int[,] ResultOfCurrentTeams = new int[teamsN, matchN];
            int[,] ResultOfOpponentTeams = new int[teamsN, matchN];
            string temp;
            for (int i = 0; i < teamsN; i++)
            {
                for (int j = 1; j < matchN; j++)
                {
                    temp = tabl[i, j];
                    if (Char.IsNumber(temp[0]))
                    {
                        ResultOfCurrentTeams[i, j-1] = temp[0] - '0'; Console.Write(ResultOfCurrentTeams[i, j-1] + "-");
                        ResultOfOpponentTeams[i, j-1] = temp[2] - '0'; Console.Write(ResultOfOpponentTeams[i, j-1] + " ");
                    }
                }
                Console.WriteLine();
            }

            int[] PointList = new int[teamsN];
            for (int i = 0; i < teamsN; i++)
            {
                for (int j = 1; j < matchN; j++)
                {
                    if (ResultOfCurrentTeams[i, j-1] > ResultOfOpponentTeams[i, j-1])
                        PointList[i] += 3;     
                    if (ResultOfCurrentTeams[i, j-1] == ResultOfOpponentTeams[i, j-1])
                        PointList[i] += 1;
                   
                }
                Console.WriteLine(PointList[i]);
                Console.WriteLine();
            }


           
        }
    }
}
