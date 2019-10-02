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
            Bitmap fight=null;
            try
            {
                fight = new Bitmap(@"image\2-4.png");
            }
            catch
            {
                MessageBox.Show("no image");
                return;
            }
            Bitmap bpm = new Bitmap(1600, 900);
            searchImg(bpm, fight);
        }
        public void searchImg(Bitmap screenimg, Bitmap findimg)
        {
            Mat screenMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(screenimg);
            Mat findMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(findimg);
            Mat res = screenMat.MatchTemplate(findMat, TemplateMatchModes.CCoeffNormed);

            double min, max;
            Cv2.MinMaxLoc(res, out min, out max);
            MessageBox.Show(max.ToString());
            screenimg.Dispose();
            findMat.Dispose();
            res.Dispose();
        }
    }
}
