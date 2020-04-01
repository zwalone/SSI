using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab_1;

namespace kNN
{
    class Program
    {
        static void Main(string[] args)
        {
            double[][] data = LoadData();
            double[] newIrys = { 0.444444444444445, 0.416666666666667, 0.694915254237288, 1.8};
            int numClassses = 3;
            int k = 4;
            int Predicted = Classify(newIrys, data, numClassses, k);
            Console.WriteLine($"Classeficated : {Predicted}");

            Console.ReadKey();
        }

        static int Classify(double[] unknow, double[][] data , int numClasses , int k)
        {
            int n = data.Length;
            IndexAndDistace[] info = new IndexAndDistace[n];
            for (int i = 0; i < n; ++i)
            {
                IndexAndDistace curr = new IndexAndDistace();
                double dist = Distance(unknow , data[i]);
                curr.idx = i;
                curr.dist = dist;
                info[i] = curr;
            }
            Array.Sort(info);
            DisplayPrediction(info, k , data);
            int result = Vote(info, data, numClasses, k);
            return result;
        }

        static double Distance(double[] unknown, double[] data)
        {
            double sum = 0.0;
            for (int i = 0; i < unknown.Length; ++i)
            {
                sum += (unknown[i] - data[i]) * (unknown[i] - data[i]);
            }
            //Console.WriteLine($"D: {Math.Sqrt(sum)}");
            return Math.Sqrt(sum);
        }

        static int Vote(IndexAndDistace[] info, double[][] trainData, int numClasses, int k)
        {
            int[] votes = new int[numClasses];
            for (int i = 0; i < k; i++)
            {
                int idx = info[i].idx;
                int c = (int)trainData[idx][4];
                ++votes[c];
                //Console.Write($"Vote {votes[c]} \n");
            }
            int mostVotes = 0;
            int classWithMostVotes = 0;

            for (int j = 0; j < numClasses; ++j)
            {
                if (votes[j] > mostVotes)
                {
                    mostVotes = votes[j];
                    classWithMostVotes = j;
                }
            }
            return classWithMostVotes;
        }

        static void DisplayPrediction(IndexAndDistace[] info, int k, double[][] data)
        {
            Console.WriteLine("Distance        Values              Class");
            for (int i = 0; i < k; ++i)
            {
                string dist = info[i].dist.ToString("F3");

                Console.WriteLine(dist + " || " + FlowerToString(data, info[i].idx,i, info));

            }
        }

        static String FlowerToString(double[][] data, int idx, int i ,IndexAndDistace[] info)
        {
            
            return String.Format("{0:0.00} | {1:0.00} | {2:0.00} | {3:0.00} | {4} ",
                    data[idx][0], data[idx][1], data[idx][2], data[idx][3], data[idx][4] ,info[i].dist );

        }

        static double[][] LoadData()
        {
            string path = @"C:\Users\Dariusz\Desktop\Studia\Rok2\Semestr 4\Systemy_Sztucznej_Inteligencji\Irysy\Data.txt";

            string[] lines = File.ReadAllLines(path);

            double[][] data = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(',');

                data[i] = new double[temp.Length];

                for (int j = 0; j < temp.Length - 1; j++)
                {
                    data[i][j] = Convert.ToDouble(temp[j].Replace('.', ','));
                }

                for (int k = 0; k < 3; k++)
                {
                    if (temp[4] == "Iris-setosa")
                    {
                        data[i][4] = 0;

                    }
                    else if (temp[4] == "Iris-versicolor")
                    {
                        data[i][4] = 1;
                      
                    }
                    else if (temp[4] == "Iris-virginica")
                    {
                        data[i][4] = 2;
                       
                    }
                }

            }

            norma normalize = new norma();
            for (int i = 0; i < 3; i++)
            {
                data = normalize.DoNormalize(data, i, 1, 0);
            }

            
            return data;
        }
    }
}
