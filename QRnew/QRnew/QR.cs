using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.QrCode;
using System.Drawing;
using Microsoft.Win32;

namespace QRnew
{
    class QR
    {
        private int width, height; //
        private QrCodeEncodingOptions options;
        public QR()
        {
            width = 300;
            height = 300;
            options = new QrCodeEncodingOptions { DisableECI = true, CharacterSet = "UTF-8", Width = width, Height = height };
        }
        public QR(int w, int h)
        {
            width = w;
            height = h;
            options = new QrCodeEncodingOptions { DisableECI = true, CharacterSet = "UTF-8", Width = width, Height = height };
        }
        //public ~QR() { }
        public ImageSource textOrURL(string TeXt)
        {
            BarcodeWriter qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            Bitmap result = new Bitmap(qr.Write(TeXt));
            BitmapSource b = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(result.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageSource IM = b;
            return b;
        }

        public void SaveQR()
        {
            SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "QR"; // Default file name
            dlg.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp"; // Filter files by extension
            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
        }
    }
}
