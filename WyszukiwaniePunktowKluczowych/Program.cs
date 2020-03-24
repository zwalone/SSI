using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WyszukiwaniePunktowKluczowych
{
    class Program
    {
        static void Main(string[] args)
        {
            WyszukiwaniePunktow wybrany = new WyszukiwaniePunktow(@"C:\Users\Dariusz\Desktop\NewIrys.jpg");
            wybrany.Draw();
        }
    }
}
