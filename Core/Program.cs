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
    public enum RESOLUTION
    {

    }

    class Program
    {
        const string imgPath = "img/original";

        static void Main(string[] args)
        {
            Console.WriteLine("type \"android\" or \"ios\" to resize for the right platform");

            new Resizer().GetTerminalInput();

            Console.WriteLine("Resizing, please wait...");
            Console.WriteLine("Resizing done! Press enter to close the program.");
            Console.ReadLine();
        }


  
    }
}