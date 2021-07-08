using System.Windows.Controls;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ZXing;
using ZXing.QrCode;
using System.Drawing;

namespace QRnew
{

    public partial class MainWindow : Window
    {
        QR qr = new QR();
        ImageSource qrimage;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void QRType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (QRType.SelectedItem)
            {
                case -1:
                    break;
                case 0: //text
                case 1: //url
                    {
                        Text.Visibility = Visibility.Visible;
                        qrimage = qr.textOrURL(Text.Text.Trim());
                        break;
                    }
                case 2:
                    break;
                case 3: //pic
                    break;
                default:
                    break;
            }

            Text.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            image.Source = qrimage;  //
            Text.Clear();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            qr.SaveQR();
        }
    }
}
