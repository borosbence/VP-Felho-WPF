using Microsoft.Win32;
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
using System.Windows.Shapes;
using VP_Felho.Models;
using VP_Felho.ViewModels;

namespace VP_Felho.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        private MainViewModel viewModel;
        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;
        public MainView()
        {
            InitializeComponent();
            viewModel = this.DataContext as MainViewModel;
            saveFileDialog = new SaveFileDialog();
            openFileDialog = new OpenFileDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog.FileName = null;
            //openFileDialog1.Filter = "Word dokumentumok (*.docx)|*.docx|Minden fájl (*.*)|*.*";
            openFileDialog.Filter = "Minden típus (*.*) | *.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var teljesFajlnev = openFileDialog.FileName;
                // Kiválasztottuk a feltöltendő fájlt
                if (!string.IsNullOrEmpty(teljesFajlnev))
                {
                    var fajl = new Fajl(
                        openFileDialog.SafeFileName,
                        System.IO.Path.GetExtension(teljesFajlnev),
                        File.ReadAllBytes(teljesFajlnev));
                    viewModel.UploadCommand.Execute(fajl);
                }
            }
        }

        private void listBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            saveFileDialog.FileName = viewModel.SelectedFajl.fajlnev;
            saveFileDialog.Filter = "Minden típus | *.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                // Ha a fájlnév mező nem üres
                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    File.WriteAllBytes(saveFileDialog.FileName, viewModel.SelectedFajl.adat);
                }
            }
        }
    }
}
