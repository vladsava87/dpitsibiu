using CatalogDesktopApp.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace CatalogDesktopApp.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public LoginWindowViewModel()
        {
            LoginButtonClick = new RelayCommand(MyLoginButtonClick);
          //  UserName = new RelayCommand(MyUserName);
            ForgotPasswordButtonClick = new RelayCommand(MyForgotPasswordButtonClick);
        }


        private void MyLoginButtonClick(object obj)
        {
            string Username = UsernameTextBox;
            string Password = PasswordTextBox;
        }

        private void MyForgotPasswordButtonClick(object obj)
        {

        }

       

        public ICommand LoginButtonClick { get; set; }
        public ICommand ForgotPasswordButtonClick { get; set; }
      //  public ICommand UserName { get; set; }

        public string UsernameTextBox { get; set; }
        public string PasswordTextBox { get; set; }
        



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
