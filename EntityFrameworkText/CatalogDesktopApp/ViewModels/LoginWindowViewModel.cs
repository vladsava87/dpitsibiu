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
using CatalogDesktopApp.Services;
using CatalogDesktopApp.Util;

namespace CatalogDesktopApp.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private UserService _userService;

        public LoginWindowViewModel()
        {
            LoginButtonClick = new RelayCommand(MyLoginButtonClick);
          //  UserName = new RelayCommand(MyUserName);
            ForgotPasswordButtonClick = new RelayCommand(MyForgotPasswordButtonClick);

            _messageBus = MessageBus.Instance;
            _userService = UserService.Instance;
        }


        private async void MyLoginButtonClick(object obj)
        {
            //string Username = "AlexAlexandrescu@elev.ro";
            //string Password = "1234";

            string hashPassword = Password.CalculateMD5Hash(PasswordTextBox);

            var ret = await _userService.PerformLogin(UsernameTextBox, hashPassword);

            if (ret != null)
            {
                var mesg = new TestMessage();
                mesg.Str = ret;

                _messageBus.Publish(mesg);
            }
        }

        private void MyForgotPasswordButtonClick(object obj)
        {

        }

       

        public ICommand LoginButtonClick { get; set; }
        public ICommand ForgotPasswordButtonClick { get; set; }
      //  public ICommand UserName { get; set; }

        public string UsernameTextBox { get; set; }
        public string PasswordTextBox { get; set; }
        
    }
}
