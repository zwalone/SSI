using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_1;

namespace FuzzyLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Dariusz\Desktop\Studia\Rok2\Semestr 4\Systemy_Sztucznej_Inteligencji\Irysy\Data.txt";

            double[][] data;
            DataFlowers dataFlowers = new DataFlowers();
            norma normalize = new norma();

            data = dataFlowers.ReadData(path);

            for (int i = 0; i < 3; i++)
            {
                data = normalize.DoNormalize(data, i, 1, 0);
            }

            Logic logic = new Logic();
            logic.FuzzyLogic(data);
            Console.ReadKey();

        }

    }
}
