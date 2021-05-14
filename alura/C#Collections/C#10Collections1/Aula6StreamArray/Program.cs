
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Aula6StreamArray
{
	class Program
	{
		static void Main(string[] args)
		{
			var img = ImageManipulator.ReadImage("./static/Ford_Logo.jpg");

			var cuttedImage = ImageManipulator.CutImageInUpperHalf(img);
			ImageManipulator.SaveImage("teste corte", cuttedImage, ImageFormat.Jpeg);
		}
	}
}
