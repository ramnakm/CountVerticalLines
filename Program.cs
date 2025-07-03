// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        string imagePath;

#if DEBUG
        // Allow developer input in debug mode if no args provided
        if (args.Length == 0)
        {
            Console.WriteLine("[DEBUG] No command-line argument provided.");
            Console.Write("Enter full image path: ");
            //imagePath = args[0];
            imagePath = Console.ReadLine().Trim();
        }
        else if (args.Length == 1)
        {
            imagePath = args[0];
        }
        else
        {
            Console.WriteLine("Error: Please provide exactly one image file path.");
            return;
        }
#else

        // Release mode: strictly require 1 argument
            if (args.Length != 1)
            {
                Console.WriteLine("Error: Please provide exactly one image file path.");
                return;
            }

            imagePath = args[0];
#endif

        try
        {
            //imagePath = args[0];

            // Validate file existence
            if (!File.Exists(imagePath)) 
            {
                Console.WriteLine("Error: File does not exist");
                return;
            }

            // Load image
            Bitmap bmp = new Bitmap(imagePath);
            int width = bmp.Width;
            int height = bmp.Height;

            // Store which columns have black pixels
            bool[] isBlackline = new bool[width];

            // Scan for black pixels in each column
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

            // Count transitions from white to black columns
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
    }

    /// <summary>
    /// Checks if a pixel is black
    /// </summary>
    /// <param name="pxColor"></param>
    /// <returns></returns>
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