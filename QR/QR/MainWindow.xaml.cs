using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Drawing;

namespace QR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        QrCodeEncodingOptions options;
        QR qr = new QR();
        public MainWindow()
        {
            InitializeComponent();


            qr.options(options);

        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            
            switch (QRType.SelectedItem)
            {
                case -1:
                    break;
                case 0:
                    {
                        //text
                        qr.textOrURL(options);
                    break;
                    }
                    
                case 1:
                    {
                        //text
                        qr.textOrURL(options);
                        break;
                    }
                case 2:
                    break;
                case 3: //pic
                    break;
                default:
                    break;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (QRType.SelectedItem)
            {
                case -1:
                    break;
                case 0: textbox.Visibility = Visibility.Visible; //text
                    break;
                case 1: textbox.Visibility = Visibility.Visible; //url
                    break;
                case 2:
                    break;
                case 3: //pic
                    break;
                default:
                    break;
            }

            textbox.Visibility = Visibility.Visible;
        }
    }
}
