using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ColorConverter
    {
        const string imgPath = "img/original";

        public ColorConverter()
        {

        }

        public void ConvertToGrayScale(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path, "*.png"))
                {
                    using (Bitmap image = new Bitmap(Image.FromFile(file)))
                    {
                        Bitmap grayScaled = image.Clone(new Rectangle(1800, 1800, 2200, 2200), System.Drawing.Imaging.PixelFormat.Format16bppGrayScale);

                        grayScaled.Save("img/resized/" + file.Split('/')[1].Split(Path.DirectorySeparatorChar)[1]);
                        grayScaled.Dispose();
                        image.Dispose();
                    }
                }
                
            }
        }

        Rectangle ReturnRectangle(int width, int height)
        {
            Rectangle rect = new Rectangle();

            int totalWidth = rect.Left + rect.Width; //think -the same as Right property

            int allowableWidth = width - rect.Left;

            int finalWidth = 0;

            if (totalWidth > allowableWidth)
            {
                finalWidth = allowableWidth;
            }
            else
            {
                finalWidth = totalWidth;
            }

            rect.Width = finalWidth;

            int totalHeight = rect.Top + rect.Height; //think same as Bottom property
            int allowableHeight = height - rect.Top;
            int finalHeight = 0;

            if (totalHeight > allowableHeight)
            {
                finalHeight = allowableHeight;
            }
            else
            {
                finalHeight = totalHeight;
            }

            rect.Height = finalHeight;

            return rect;
        }
    }
}
