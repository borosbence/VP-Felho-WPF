using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VP_Felho.Models;
using VP_Felho.Repositories;
using VP_Felho.Views;

namespace VP_Felho.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); LoginCommand.NotifyCanExecuteChanged(); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); LoginCommand.NotifyCanExecuteChanged(); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        private FelhasznaloRepository repo;
        public RelayCommand LoginCommand { get; set; }

        public LoginViewModel()
        {
            repo = new FelhasznaloRepository(new felhoContext());
            LoginCommand = new RelayCommand(() => Login(), () => CanLogin());
        }

        private bool CanLogin()
        {
            return !string.IsNullOrWhiteSpace(_username) && !string.IsNullOrWhiteSpace(_password);
        }

        private void Login()
        {
            ErrorMessage = repo.Authenticate(_username, _password);
            if (ErrorMessage == Application.Current.Resources["loginSuccess"].ToString())
            {
                var mw = new MainView();
                Application.Current.Windows[0].Close();
                mw.Show();
            }
        }
    }
}
