using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using VP_Felho.Models;

namespace VP_Felho.ViewModels
{
    public class DisplayImageViewModel
    {
        public ImageSource ImageSource { get; set; }

        public DisplayImageViewModel(Fajl fajl)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = new MemoryStream(fajl.adat);
            bmp.EndInit();
            ImageSource = bmp;
        }
    }
}
