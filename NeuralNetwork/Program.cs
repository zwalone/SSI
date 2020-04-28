using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Lab_1;

namespace NeuralNetwork
{
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
                    data[i][j] = Convert.ToDouble(temp[j].Replace('.', ','));
                }

                for (int k = 0; k < 3; k++)
                {
                    if (temp[4] == "Iris-setosa")
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
                    else if (temp[4] == "Iris-virginica")
                    {
                        data[i][4] = 1;
                        data[i][5] = 0;
                        data[i][6] = 0;
                    }
                }

            }

            norma norm = new norma();

            for (int i = 0; i < 3; i++)
            {
                data = norm.DoNormalize(data, i, 1, 0);
            }

            data = norm.Shuffle(data);


            double[][] expectedValue = new double[data.Length][];
            double[][] trainData = new double[data.Length][];

            for (int i = 0; i < data.Length; i++)
            {
                trainData[i] = new double[4];
                expectedValue[i] = new double[3];
                for (int j = 0; j < 4; j++)
                {
                    trainData[i][j] = data[i][j];
                }
                for (int j = 0; j < 3; j++)
                {
                    expectedValue[i][j] = data[i][j + 4];
                }
            }


            //Network
            Network network = new Network(4, 2, 4, 3);
            network.PushExpectedValue(expectedValue);

            network.Train(trainData, 0.3);


            Console.ReadKey();
        }
    }
}
