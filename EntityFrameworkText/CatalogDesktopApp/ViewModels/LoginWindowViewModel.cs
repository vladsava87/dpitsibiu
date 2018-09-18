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
using Newtonsoft.Json;

namespace CatalogDesktopApp.ViewModels
{
    public class LoginWindowViewModel : ViewModelBase
    {
        private MessageBus _messageBus;
        private UserService _userService;

        private bool isPerformingLogin;

        public LoginWindowViewModel()
        {
            LoginButtonClick = new RelayCommand(MyLoginButtonClick, CanLogin);
          //  UserName = new RelayCommand(MyUserName);
            ForgotPasswordButtonClick = new RelayCommand(MyForgotPasswordButtonClick);

            _messageBus = MessageBus.Instance;
            _userService = UserService.Instance;
        }

        private bool CanLogin(object arg)
        {
            return !isPerformingLogin;
        }

        private async void MyLoginButtonClick(object obj)
        {
            //string Username = "AlexAlexandrescu@elev.ro";
            //string Password = "1234";
            isPerformingLogin = true;

            string hashPassword = Password.CalculateMD5Hash(PasswordTextBox);

            var ret = await _userService.PerformLogin(UsernameTextBox, hashPassword);

            if (ret != null)
            {
                App.UtilizatorCurent = JsonConvert.DeserializeObject<Utilizator>(ret);

                var mesg = new LoginMessage();
                mesg.Str = ret;

                _messageBus.Publish(mesg);
            }

            isPerformingLogin = false;
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
