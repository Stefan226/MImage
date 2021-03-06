﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core
{
    public class Resizer
    {
        public Resizer()
        {

        }

        public void ResizeToDivBy4(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path, "*.png"))
                {
                    using (Bitmap image = new Bitmap(Image.FromFile(file)))
                    {
                        int imgH = image.Height;
                        int imgW = image.Width;

                        while (imgH % 4 != 0)
                            imgH--;
                        while (imgW % 4 != 0)
                            imgW--;

                        if (imgH != image.Height || imgW != image.Width)
                        {
                            Bitmap resizedImage = new Bitmap(image, new Size(imgW, imgH));
                            resizedImage.Save("img/resized/" + file.Split('/')[1].Split(Path.DirectorySeparatorChar)[1]);
                            resizedImage.Dispose();
                        }
                        image.Dispose();
                    }
                }
            }
        }

        public void ResizeToDivBy2AndSqrt(string path)
        {
            if (Directory.Exists(path))
            {
                foreach (string file in Directory.GetFiles(path, "*.png"))
                {
                    using (Bitmap image = new Bitmap(Image.FromFile(file)))
                    {
                        int po2Width = ReturnNextPO2(image.Width);
                        int po2Height = ReturnNextPO2(image.Height);
                        int posX = GetNewPosition(po2Width, image.Width);
                        int posY = GetNewPosition(po2Height, image.Height);

                        Bitmap newImage = new Bitmap(po2Width, po2Height);
                        using (Graphics graphics = Graphics.FromImage(newImage))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            graphics.CompositingMode = CompositingMode.SourceCopy;
                            graphics.DrawImage(image, posX, posY, image.Width, image.Height);

                            var qualityParamId = Encoder.Quality;
                            var encoderParameters = new EncoderParameters(1);
                            encoderParameters.Param[0] = new EncoderParameter(qualityParamId, 100);
                            var codec = ImageCodecInfo.GetImageDecoders().FirstOrDefault(_codec => _codec.FormatID == ImageFormat.Png.Guid);
                            newImage.Save("img/resized/" + file.Split('/')[1].Split(Path.DirectorySeparatorChar)[1], codec, encoderParameters);
                        }
                        image.Dispose();
                        newImage.Dispose();
                    }
                }
            }
        }


        int ReturnNextPO2(int value)
        {
            for (int i = 0; i < 20; i++)
            {
                if (CheckInterval(value, GetPO2Value(i), GetPO2Value(i + 1)))
                {
                    //if (value <= GetPO2Value(i) + 20)  //needs to be improved
                    //    return GetPO2Value(i);
                    //else
                        return GetPO2Value(i + 1);
                }
            }
            return value;
        }

        bool CheckInterval(int value, int min, int max)
        {
            return value > min && value < max;
        }

        int GetPO2Value(int i)
        {
            return (int)Math.Pow(2, i);
        }

        int GetNewPosition(int valuePO2, int originalRes)
        {
            return (valuePO2 - originalRes) / 2;
        }
    }
}
