using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Net;
using System.IO;

namespace YACRScontrol
{
    class YACRSUtil
    {
        private static int imgWidth = 640;

        public static byte[] grabScreenAsPNG(PointF containing)
        {
            // Grab screen
            Screen grabscreen;
            if ((containing.X == -1) && (containing.Y == -1))
            {
                grabscreen = Screen.PrimaryScreen;
            }
            else
            {
                grabscreen = Screen.FromPoint(new Point((int)containing.X, (int)containing.Y));
            }

            Bitmap bmpScreenCapture = new Bitmap(grabscreen.Bounds.Width, grabscreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bmpScreenCapture);
            g.CopyFromScreen(grabscreen.Bounds.X, grabscreen.Bounds.Y, 0, 0, bmpScreenCapture.Size, CopyPixelOperation.SourceCopy);

            // Resize to imgWidth pix wide
            int newWidth = imgWidth;
            int newHeight = (int)((bmpScreenCapture.Height * imgWidth) / bmpScreenCapture.Width);

            Bitmap resized = new Bitmap(newWidth, newHeight, PixelFormat.Format24bppRgb);
            resized.SetResolution(bmpScreenCapture.HorizontalResolution, bmpScreenCapture.VerticalResolution);

            using (g = Graphics.FromImage(resized))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                g.DrawImage(bmpScreenCapture, 0, 0, resized.Width, resized.Height);
            }
            byte[] result = null;
            using (MemoryStream stream = new MemoryStream())
            {
                resized.Save(stream, ImageFormat.Png);
                result = stream.ToArray();
            }
            return result;
        }
    }
}
