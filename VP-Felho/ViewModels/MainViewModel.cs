using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VP_Felho.Models;
using VP_Felho.Repositories;
using VP_Felho.Views;

namespace VP_Felho.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private GenericRepository<Fajl, felhoContext> _repo;

        public ObservableCollection<Fajl> Fajlok { get; set; }

        private Fajl _selectedFajl;
        public Fajl SelectedFajl
        {
            get { return _selectedFajl; }
            set { SetProperty(ref _selectedFajl, value); 
                DisplayCommand.NotifyCanExecuteChanged();
                RemoveCommand.NotifyCanExecuteChanged();
            }
        }

        public RelayCommand DisplayCommand { get; set; }
        public RelayCommand<Fajl> UploadCommand { get; set; }
        public RelayCommand RemoveCommand { get; set; }
        public RelayCommand<Window> LogoutCommand { get; set; }

        public MainViewModel()
        {
            _repo = new GenericRepository<Fajl, felhoContext>(new felhoContext());
            Fajlok = new ObservableCollection<Fajl>(_repo.GetAll());
            DisplayCommand = new RelayCommand(() => Display(), () => CanDisplay());
            UploadCommand = new RelayCommand<Fajl>(fajl => AddItem(fajl));
            RemoveCommand = new RelayCommand(() => RemoveItem(), () => CanRemove());
            LogoutCommand = new RelayCommand<Window>(e => Close(e));
        }

        private void AddItem(Fajl fajl)
        {
            _repo.Insert(fajl);
            Fajlok.Insert(0, fajl);
        }

        private void Display()
        {
            DisplayImageViewModel dpViewModel = new DisplayImageViewModel(SelectedFajl);
            DisplayImageView dpView = new DisplayImageView(dpViewModel);
            dpView.ShowDialog();
        }

        private bool CanDisplay()
        {
            if (SelectedFajl == null)
            {
                return false;
            }
            string[] imageExtensions = new string[] { ".png", ".jpg" };
            return imageExtensions.Contains(SelectedFajl.kiterjesztes.ToLower());
        }

        private bool CanRemove()
        {
            return SelectedFajl != null;
        }

        private void RemoveItem()
        {
            _repo.Delete(SelectedFajl.id);
            Fajlok.Remove(SelectedFajl);
        }

        private void Close(Window window)
        {
            var loginView = new LoginView();
            loginView.Show();
            window.Close();
        }
    }
}
