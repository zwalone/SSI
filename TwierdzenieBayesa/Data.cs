using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TwierdzenieBayesa
{
    class Data
    {
        string[][] data;

        public Data(string path)
        {
            string[] lines = File.ReadAllLines(path);
            data = new string[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] temp = lines[i].Split(' ');
                data[i] = new string[temp.Length];

                for (int j = 0; j < temp.Length; j++)
                {
                    data[i][j] = temp[j];
                }
            }
        }

        public void ChangeTemp(int index, double p1 , double p2 )
        {
            for (int i = 0; i < data.Length; i++)
            {
                if(double.Parse(data[i][index]) <= p1)
                {
                    data[i][index] = "chlodno";
                }
                else if (double.Parse(data[i][index]) <= p2)
                {
                    data[i][index] = "cieplo";
                }
                else
                {
                    data[i][index] = "goraco";
                }
            }
        }

        public void PrintData()
        {
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    Console.Write($"{data[i][j]}  ");
                }
                Console.WriteLine();
            }
        }

        public int getNumberOf(string s , int index)
        {
            int count = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][index] == s)
                {
                    count++;
                }
            }
            return count;
        }

        public int getNumberOf(string s1 ,int indx1, string s2 , int indx2)
        {
            int count = 0;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][indx1] == s1 && data[i][indx2] == s2)
                {
                    count++;
                }
            }
            return count;
        }

        public int Len { get { return data.Length; }}
    }
}
