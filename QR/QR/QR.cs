using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

namespace QR
{
    class QR
    {
        private int width, height;
    public QR() {
            width = 300;
            height = 300;
        }
        public QR(int w, int h) {
            width = w;
            height = h;
        }
        //public ~QR() { }
        public void textOrURL(QrCodeEncodingOptions options) {
            BarcodeWriter qr = new BarcodeWriter();
            qr.Options = options;
            qr.Format = ZXing.BarcodeFormat.QR_CODE;
            Bitmap result = new Bitmap(qr.Write(textbox.Text.Trim()));
            System.Windows.Media.Imaging.BitmapSource b = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                result.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            ImageSource IM = b;
            image.Source = IM;
            textbox.Clear();
        }
        public void options(QrCodeEncodingOptions options)
        {
            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = width,
                Height = height,
            };
        }


    }
}
