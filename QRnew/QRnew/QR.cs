using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using Microsoft.Win32;
using System.IO;

namespace QRnew
{
    class QR
    {
        private int width, height; //
        private QrCodeEncodingOptions options;
        BarcodeWriter qr;
        public Bitmap bmp;
        public QR()
        {
            width = 300;
            height = 300;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions { DisableECI = true, CharacterSet = "UTF-8", Width = width, Height = height };
            qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
        }
        public QR(int w, int h)
        {
            width = w;
            height = h;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions { DisableECI = true, CharacterSet = "UTF-8", Width = width, Height = height };
            qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
        }
        //public ~QR() { }
        public ImageSource textOrURL(string TeXt)
        {
            Bitmap result = new Bitmap(qr.Write(TeXt));
            bmp = result;
            BitmapSource b = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(result.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageSource IM = b;
            return b;
        }

        public ImageSource image()
        {
            return ImageSource f;
        }
        public void SaveQR(Image bmp1)
        {
            SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "QR"; // Default file name
            dlg.Filter = "PNG|*.png|JPEG|*.jpeg|GIF|*.gif|BMP|*.bmp"; // Filter files by extension
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                string format = dlg.Filter;
                switch (format)
                {
                    case "png":
                        {
                            bmp1.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                            break;
                        }
                    case "jpeg":
                        {
                            bmp1.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;
                        }
                    case "gif":
                        {
                            bmp1.Save(filename, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        }
                    case "bmp":
                        {
                            bmp1.Save(filename, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;
                        }
                }
                //bmp1.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        public ImageSource openfile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            string filename = ofd.FileName;
            //string text = File.ReadAllText(filename); надо для картинки
            ImageSource img = null;
            return img;
        }

        
    }
}
