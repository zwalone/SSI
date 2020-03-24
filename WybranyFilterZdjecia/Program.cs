using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WybranyFilterZdjecia
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path = @"C:\Users\Dariusz\Desktop\irys.jpg";

            Bitmap img = new Bitmap(path);
            Bitmap img2 = new Bitmap(img.Width, img.Height);

            double[][] kernel = new double[3][];
            kernel[0] = new double[] { -1 , -1 ,-1};
            kernel[1] = new double[] { -1, 8, -1 };
            kernel[2] = new double[] { -1, -1, -1 };


            for (int i = 1; i < img.Width-1; i++)
            {
                for (int j = 1; j < img.Height-1; j++)
                {
                    //Color pxl = img.GetPixel(i ,j);
                    double sR = 0, sG = 0, sB = 0;

                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            Color pxl2 = img.GetPixel( i + k, j+l );
                            sR += pxl2.R * kernel[k+1][l+1];
                            sG += pxl2.G * kernel[k+1][l+1];
                            sB += pxl2.B * kernel[k+1][l+1];
                        }
                    }

                    if (sR < 0) { sR = 0; }
                    if (sR > 255) { sR = 255; }
                    if (sG < 0) { sG = 0; }
                    if (sG > 255) { sG = 255; }
                    if (sB < 0) { sB = 0; }

                    if (sB > 255) { sB = 255; }

                    //Console.WriteLine($"sR : {sR}  sG: {sG} sB: {sB}");
                    img2.SetPixel(i, j, Color.FromArgb((int)sR ,(int)sG,(int)sB));
                }
            }
            //Console.ReadKey();
            img2.Save(@"C:\Users\Dariusz\Desktop\NewIrys.jpg");
        }
    }
}
