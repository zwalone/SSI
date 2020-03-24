using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1;
using System.IO;
using System.Drawing;

namespace Irysy
{   
    //w 4 kolumn normalizacja
    //i przetasowanie 
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Dariusz\Desktop\Studia\Rok2\Semestr 4\Systemy_Sztucznej_Inteligencji\Irysy\Data.txt";

            string[] lines = File.ReadAllLines(path);

            double[][] data = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');
                
                data[i] = new double[temp.Length + 2];

                for (int j = 0; j < temp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(temp[j].Replace('.',','));
                }

                for (int k = 0; k < 3; k++)
                {
                    if(temp[4] == "Iris-setosa")
                    {
                        data[i][4] = 0;
                        data[i][5] = 0;
                        data[i][6] = 1;
                    }
                    else if (temp[4] == "Iris-versicolor")
                    {
                        data[i][4] = 0;
                        data[i][5] = 1;
                        data[i][6] = 0;
                    }
                    else if(temp[4] == "Iris-virginica")
                    {
                        data[i][4] = 1;
                        data[i][5] = 0;
                        data[i][6] = 0;
                    }
                }
               
            }

            norma normalize = new norma();
            for(int i = 0; i < 3; i++)
            {
                data = normalize.DoNormalize(data, i, 1, 0);
            }


            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    Console.Write("\t");
                }
                Console.Write("\n");
            }

            /////
            Console.Write("\n ============ \n");
            data = normalize.Shuffle(data);

            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write(data[i][j]);
                    Console.Write("          ");
                }
                Console.Write("\n");
            }
            Console.ReadKey();
        }


    }
}
