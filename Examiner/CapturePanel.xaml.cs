using System;
using System.Collections.Generic;
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
using Examiner;

namespace Examiner
{
    /// <summary>
    /// Interaction logic for CapturePanel.xaml
    /// </summary>
    public partial class CapturePanel : UserControl
    {
        private MainWindowViewModel mainWindowViewModel;
        public CapturePanel()
        {
            InitializeComponent();
            mainWindowViewModel= new MainWindowViewModel();
            this.DataContext = mainWindowViewModel;
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                BitmapSource image = mainWindowViewModel.Preview;
                using (var fileStream = new FileStream(@"D://1.png", FileMode.Create))
                {
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(fileStream);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
