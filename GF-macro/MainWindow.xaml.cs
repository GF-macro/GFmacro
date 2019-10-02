using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using OpenCvSharp;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace GF_macro
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mat screen = null, find = null, res = null;
            try
            {
                Bitmap fight2_4 = new Bitmap(Environment.CurrentDirectory + "./image/2-4.png");
                screen = OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)fight2_4);
                find = OpenCvSharp.Extensions.BitmapConverter.ToMat(new Bitmap(fight2_4));

                res = screen.MatchTemplate(find, TemplateMatchModes.CCoeffNormed);
                //screen=OpenCvSharp.Extensions.BitmapConverter.ToMat((Bitmap)picturebox)
                double min, max;
                Cv2.MinMaxLoc(res, out min, out max);
                MessageBox.Show(max.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("no image");
            }
        }
    }
}
