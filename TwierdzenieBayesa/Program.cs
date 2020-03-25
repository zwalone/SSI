using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwierdzenieBayesa
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] line = new string[3];
            line[0] = "deszczowo";
            line[1] = "goraco";
            line[2] = "slaby";

            Data data = new Data(@"C:\Users\Dariusz\Desktop\Studia\Rok2\Semestr 4\Systemy_Sztucznej_Inteligencji\Irysy\Bayesa.txt");
            
            data.ChangeTemp(1, 16, 20);
            

            int[] yes = new int[line.Length + 1];
            int[] no = new int[line.Length + 1];

            yes[0] = data.getNumberOf("tak", 3);
            no[0] = data.getNumberOf("nie", 3);

            //Get numbers
            for (int i = 1; i < yes.Length; i++)
            {
                yes[i] = data.getNumberOf(line[i - 1], i - 1, "tak", 3);
                no[i] = data.getNumberOf(line[i - 1], i - 1, "nie", 3);
            }

            double y = (double)yes[0] / (double)data.Len;
            double n  = (double)no[0] / (double)data.Len;
            for (int i = 1; i < yes.Length; i++)
            {
                y *= ((double)yes[i] / (double)yes[0]);
                n *= ((double)no[i] / (double)no[0]);
            }

            if (y > n)
            {
                Console.Write("Decyzja : tak");
            }
            else
            {
                Console.Write("Decyzja : nie");
            }
            

            Console.ReadKey();
        }
    }
}
