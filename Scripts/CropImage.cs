using System;
using System.Drawing;
using System.Drawing.Imaging;


namespace  SoftSpace_web.Scripts
{
    static class CropImage
    {
        
            public static Image Crop(this Image image, Rectangle selection)
                {
                    Bitmap bmp = new Bitmap(image);

                    // Check if it is a bitmap:
                    if (bmp == null)
                        throw new ArgumentException("No valid bitmap");

                    // Crop the image:
                    Console.WriteLine(image.Height + " -- -- -- " + image.Width);
                    Bitmap cropBmp = bmp.Clone(selection, bmp.PixelFormat);

                    // Release the resources:
                    image.Dispose();

                    return cropBmp;
                }
        
    }
}