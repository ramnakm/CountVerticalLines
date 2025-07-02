// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;
//using System.Drawing.Common;

internal class Program
{
    private static void Main(string[] args)
    {
        string inpFolder = @"..\..\..\Images";
        string absPath = Path.GetFullPath(inpFolder);
        

        foreach (string filePath in Directory.GetFiles(absPath))
        {
            Bitmap bmp = new Bitmap(filePath);

            int width = bmp.Width;
            int height = bmp.Height;
            int threshold = 0;
            
            bool[] isBlackline = new bool[width];

            for (int i = 0; i < width; i++)
            {
                int linePixels = 0;
                bool isPreviousBlack = false;
                

                for (int j = 0; j < height; j++)
                {
                    Color pxColor = bmp.GetPixel(i, j);

                    if (isBlack(pxColor))
                    {
                        isBlackline[i] = true;
                        break; // Found black pixel in this column, move to next column
                    }
                    
                }
            }

            int lineCount = 0;
            bool prevline = false;

            // Count vertical lines by checking transitions in blackline[]
            for (int i = 0; i < width; i++)
            {
                if (isBlackline[i])
                {
                    if (!prevline)
                    {
                        lineCount++;
                        prevline = true;
                    }
                }
                else 
                {
                    prevline = false;
                }
            }

                Console.WriteLine("No of Vertical Lines in " + Path.GetFileName(filePath) + " : " + lineCount);
        }
        Console.ReadKey();
    }

    public static bool isBlack(Color pxColor)
    {
        if(pxColor.R < 50 && pxColor.G < 50 && pxColor.B < 50)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}