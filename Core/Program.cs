using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    class Program
    {
        const string imgPath = "img/original";

        static void Main(string[] args)
        {
            Console.WriteLine("type \"android\" or \"ios\" to resize for the right platform");

            GetTerminalInput();

            Console.WriteLine("Resizing, please wait...");
            Console.WriteLine("Resizing done! Press enter to close the program.");
            Console.ReadLine();
        }

        static void GetTerminalInput()
        {
            switch (Console.ReadLine())
            {
                case "android":
                    new Resizer().ResizeToDivBy4(imgPath);
                    return;
                case "ios":
                    new Resizer().ResizeToDivBy2AndSqrt(imgPath);
                    return;
                case "grayscale":
                    new ColorConverter().ConvertToGrayScale(imgPath);
                    break;
            }
            Console.WriteLine("Wrong input!");
            GetTerminalInput();
        }

    }
}