using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WyszukiwaniePunktowKluczowych
{
    class WyszukiwaniePunktow
    {
        Bitmap img1;
        Bitmap img2;
        double[][] points;
        bool[][] finded;

        public WyszukiwaniePunktow(string path)
        {
            img1 = new Bitmap(path);
            img2 = img1;
            points = new double[3][];
            points[0] = new double[] { 50, 80, 200};
            points[1] = new double[] { 80, 254, 80};
            points[2] = new double[] { 200, 80, 50};

            finded = new bool[3][];
            finded[0] = new bool[] { false, false, false };
            finded[1] = new bool[] { false, false, false };
            finded[2] = new bool[] { false, false, false };
        }

        public void Draw()
        {
            for (int i = 1; i < img1.Width-1; i++)
            {
                for (int j = 1; j < img1.Height-1; j++)
                {
                    
                    Color pxl = img1.GetPixel(i, j);
                    double cpxl = (pxl.R + pxl.G + pxl.B) / 3;
                    
                    //interesting pxl is find
                    if (cpxl > points[1][1])
                    {
                        finded[1][1] = true;

                        //Check more options
                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                if (k == 0 && l == 0) continue;

                                pxl = img1.GetPixel(i + k, j + l);
                                cpxl = (pxl.R + pxl.G + pxl.B) / 3;

                                // < ma być
                                if(cpxl < points[k + 1][l + 1])
                                {
                                    finded[k + 1][l + 1] = true;
                                }
                                else
                                {
                                    finded[k + 1][l + 1] = false;
                                }
                            }
                        }

                        if (CheckPxl(finded)) img2.SetPixel(i, j, Color.Red);
                        //img2.SetPixel(i, j, Color.Red);
                    }
                    
                }
            }

            img2.Save(@"C:\Users\Dariusz\Desktop\NewIrys222.jpg");
        }

        private bool CheckPxl (bool[][] array)
        {
            int count = 0;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (array[i][j] == true) count++;
                }
            }

            //If pxl have enough conditions true
            if (count > 3) return true;
            else return false;
        }
    }
}
