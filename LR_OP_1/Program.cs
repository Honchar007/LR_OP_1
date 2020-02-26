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
            CreateFile(tabl, c, n);
        }
        static void CreateFile(string[,] tabl, int teamsN, int matchN)
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
                        ResultOfCurrentTeams[i, j - 1] = temp[0] - '0'; //Console.Write(ResultOfCurrentTeams[i, j - 1] + "-");
                        ResultOfOpponentTeams[i, j - 1] = temp[2] - '0'; //Console.Write(ResultOfOpponentTeams[i, j - 1] + " ");
                    }
                }
               // Console.WriteLine();
              
            }
           int[]Score= Points(teamsN, matchN, ResultOfCurrentTeams, ResultOfOpponentTeams);
           string[] ResTable=new string[teamsN];
            string buf="";
            for(int i=0; i<teamsN; i++)
            {
                ResTable[i] =String.Format("{0,3} {1, -30} {2:N0}",(1+i), tabl[i, 0], Score[i]);
                buf += ResTable[i]+"\n";
               
            }
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Tournament.csv");
            File.WriteAllText(path, buf);
            Console.WriteLine(buf);
        }
         static int[] Points(int teamsN, int matchN, int[,] ResultOfCurrentTeams, int[,] ResultOfOpponentTeams)
        {
            int[] PointList = new int[teamsN];
            for (int i = 0; i < teamsN; i++)
            {
                for (int j = 1; j < matchN; j++)
                {
                    if (ResultOfCurrentTeams[i, j - 1] > ResultOfOpponentTeams[i, j - 1])
                        PointList[i] += 3;
                    if (ResultOfCurrentTeams[i, j - 1] == ResultOfOpponentTeams[i, j - 1])
                        PointList[i] += 1;

                }
               
            }

            return PointList;
        }
    } }

