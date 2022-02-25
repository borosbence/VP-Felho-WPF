using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using VP_Felho.ViewModels;

namespace VP_Felho.Views
{
    /// <summary>
    /// Interaction logic for DisplayImageView.xaml
    /// </summary>
    public partial class DisplayImageView : Window
    {
        public DisplayImageView(DisplayImageViewModel displayImageViewModel)
        {
            InitializeComponent();
            DataContext = displayImageViewModel;
        }
    }
}
