using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Aula6StreamArray
{
    public static class ImageManipulator 
	{
			public static Bitmap ReadImage(string path) 
			{	Bitmap bm;
				MemoryStream memoryStream;

				using (Stream imgStreamSrc = new FileStream(path, FileMode.Open, FileAccess.Read)) 
				{	memoryStream = new();
					int byteCount;
					byte[] buffer = new Byte[1024];

					do 
					{	byteCount = imgStreamSrc.Read(buffer, 0, buffer.Length);
						memoryStream.Write(buffer, 0, byteCount);
						System.Console.WriteLine(imgStreamSrc);
					} while (byteCount > 0);

					bm = new Bitmap(Image.FromStream(memoryStream), new Size(175,128));
					return bm;
				}
			}

			public static void SaveImage(string newFileName, Image image, ImageFormat imageFormat) 
			{	_  = image ?? throw new ArgumentException(
                                $"argument {nameof(image)} must reference an Image object",
                                nameof(image));

				image.Save($"./static/{newFileName}.{imageFormat.ToString()}", imageFormat);
			}

            private static List<Color> GetColors(Image image)
            {
                List<Color> imageColors = new List<Color>();
                if (image is Bitmap bm)
				{
                    foreach (int  width in Enumerable.Range(0, bm.Width- 1 ) )
                    {
                        foreach (int height in Enumerable.Range(0, bm.Height - 1) )
                        {
                            imageColors.Add(bm.GetPixel(width, height));
                        }
                    }
                }
                return imageColors;
            }

			public static Bitmap CutImageInUpperHalf(Bitmap originalBitmap)
			{
				var bm = new Bitmap(originalBitmap, 128, 128);
				
				Stack<Color> colors = new Stack<Color>(GetColors(originalBitmap));

				Bitmap cuttedBm = new Bitmap(128 , 128);

				for (int x = 0; x < cuttedBm.Height/2; x ++)
				{
					for(int y = 0; y < cuttedBm.Width ; y ++)
					{
						cuttedBm.SetPixel(y,x, colors.Pop());
					}
				}
				
				return cuttedBm;
			} 
		
		}
}