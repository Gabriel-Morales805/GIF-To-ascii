using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
namespace VideoTerm
{
    class Program
    {
        static void Main(string[] args)
        {
            string mypath = Console.ReadLine();
            Image image = Image.FromFile(@mypath);
            //image.dispose()
            //Features: Drag N drap Gif to ascii
            // Open source: Feel free to do whatever you want To it.
            //N/A


            FrameDimension dimension = new FrameDimension(
                               image.FrameDimensionsList[0]);
            int frameCount = image.GetFrameCount(dimension);
            StringBuilder sb;

            
            int left = Console.WindowLeft, top = Console.WindowTop;

            char[] chars = { '#', '#', '@', '%', '=', '+',
                         '*', ':', '-', '.', ' ' };
            for (int i = 0; ; i = (i + 1) % frameCount)
            {
                sb = new StringBuilder();
                image.SelectActiveFrame(dimension, i);

                for (int h = 0; h < image.Height; h++)
                {
                    for (int w = 0; w < image.Width; w++)
                    {
                        Color cl = ((Bitmap)image).GetPixel(w, h);
                        int gray = (cl.R + cl.G + cl.B) / 3;
                        int index = (gray * (chars.Length - 1)) / 255;

                        sb.Append(chars[index]);
                    }
                    sb.Append('\n');
                }
                Console.WriteLine(i);

                Console.SetCursorPosition(left, top);
                Console.Write(sb.ToString());
                
               

                System.Threading.Thread.Sleep(40);

            }
        }
    }
}

