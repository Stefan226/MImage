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
                        Color pixel;

                        for (int y = 0; y < image.Height; y++)
                        {
                            for (int x = 0; x < image.Width; x++)
                            {
                                pixel = image.GetPixel(x, y);

                                int a = pixel.A;
                                int r = pixel.R;
                                int g = pixel.G;
                                int b = pixel.B;

                                int avg = (r + g + b) / 3;

                                image.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                            }
                        }

                        Bitmap grayScaled = new Bitmap(image);

                        grayScaled.Save("img/resized/" + file.Split('/')[1].Split(Path.DirectorySeparatorChar)[1]);
                        grayScaled.Dispose();
                        image.Dispose();
                    }
                }
                
            }
        }
    }
}
