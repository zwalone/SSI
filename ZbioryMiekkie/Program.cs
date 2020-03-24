using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZbioryMiekkie
{
    class Program
    {
        static void Main(string[] args)
        {
            //drogie, tanie, jeans, dresowe, klasyczne, modern, fit, granatowe, czarne, na zamek, na guziki
            int[][] trousers = new int[6][];
            trousers[0] = new int[] { 1, 0, 1, 0, 0, 1, 1, 0, 1, 0, 1 };
            trousers[1] = new int[] { 1, 0, 0, 1, 1, 0, 0, 0, 1, 1, 0 };
            trousers[2] = new int[] { 0, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1 };
            trousers[3] = new int[] { 0, 1, 0, 1, 0, 1, 1, 0, 1, 1, 0 };
            trousers[4] = new int[] { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0, 1 };
            trousers[5] = new int[] { 0, 1, 0, 0, 1, 0, 1, 1, 0, 1, 1 };

            double[] A = new double[] { 0, 0, 0.5, 0, 0, 0.3, 0, 0, 0, 0.2, 0 };
            double[] B = new double[] { 0, 0, 0.4, 0, 0.2, 0.3, 0, 0.2, 0, 0, 0.2 };
            double[] Aeq = new double[6];
            double[] Beq = new double[6];

            Console.WriteLine("Spodnie :");
            EQ(trousers, A);
            Console.WriteLine();
            EQ(trousers, B);
            Console.WriteLine();
         

            //świeże, mrożone, ostre, słodkie, zielone, czerwone, lokalne, tropikalne, liściaste, bulwowe
            int[][] fruit = new int[6][];
            fruit[0] = new int[] { 1, 0, 1, 0, 0, 1, 1, 0, 1, 0};
            fruit[1] = new int[] { 1, 0, 0, 1, 1, 0, 0, 0, 1, 1};
            fruit[2] = new int[] { 0, 1, 1, 0, 0, 1, 1, 1, 0, 0};
            fruit[3] = new int[] { 0, 1, 0, 1, 0, 1, 1, 0, 1, 1};
            fruit[4] = new int[] { 1, 0, 1, 1, 1, 0, 1, 0, 1, 0};
            fruit[5] = new int[] { 0, 1, 0, 0, 1, 0, 1, 1, 0, 1};

            double[] AA = new double[] { 0.6, 0, 0.2, 0, 0, 0.2, 0, 0, 0, 0};
            double[] BB = new double[] { 0, 0.1, 0, 0.4, 0.2, 0, 0, 0, 0.3, 0};
            double[] CC = new double[] { 0.4, 0, 0, 0.3, 0.2, 0.1, 0, 0, 0, 0};

            Console.WriteLine("Owoce");
            EQ(fruit, AA);
            Console.WriteLine();
            EQ(fruit, BB);
            Console.WriteLine();
            EQ(fruit, CC);
            Console.WriteLine();


            Console.ReadKey();
        }

        static double Findmax(double[] tab)
        {
            double max = tab[0];
            for (int i = 0; i < tab.Length; i++)
            {
                if (max < tab[i])
                {
                    max = tab[i];
                }
            }
            return max;
        }
        
        static void EQ(int[][] items , double[] tab)
        {
            double[] eq = new double[items.Length];

            for (int i = 0; i < items.Length; i++)
            {
                double eque = 0.0;
                for (int j = 0; j < items[0].Length; j++)
                {
                    eque += items[i][j] * tab[j];
                }
                eq[i] = eque;
            }

            double max = Findmax(eq);
            for (int i = 0; i < eq.Length; i++)
            {
                if (max == eq[i])
                    Console.WriteLine($"Pan item nr {i + 1}");
            }

        }
    }
}
