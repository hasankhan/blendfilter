using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using AForge.Imaging.Filters;
using System.IO;
using AForge.Imaging;
using System.Drawing.Imaging;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var image = new Bitmap("ahyan.jpg");
            var result = PencilSketch.Sketch(image);
            result.Save("test2.jpg");

            DisplayImage(result);
        }

        void DisplayImage(Bitmap image)
        {
            var output = ToBitmapImage(image);
            imgResult.Source = output;
        }

        static BitmapImage ToBitmapImage(Bitmap image)
        {
            BitmapImage img = new BitmapImage();
            MemoryStream ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            img.BeginInit();
            img.StreamSource = ms;
            img.EndInit();
            return img;
        }
    }
}
