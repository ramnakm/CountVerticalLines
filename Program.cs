// See https://aka.ms/new-console-template for more information
using System;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Error: Please provide valid and only 1 input file path");
            return;
        }
                
        try
        {
            string imagePath = args[0];

            if (!File.Exists(imagePath)) 
            {
                Console.WriteLine("Error: File does not exist");
                return;
            }

            Bitmap bmp = new Bitmap(imagePath);

            int width = bmp.Width;
            int height = bmp.Height;            
            bool[] isBlackline = new bool[width];

            for (int i = 0; i < width; i++)
            {     
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

            Console.WriteLine("No of Vertical Lines in " + Path.GetFileName(imagePath) + " : " + lineCount);
        }
        catch (Exception ex)
        { 
            Console.WriteLine(ex.ToString());   
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