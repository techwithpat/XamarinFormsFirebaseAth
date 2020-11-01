using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamFormsFirebaseAuth.Features.Common;
using XamFormsFirebaseAuth.Framework;

namespace XamFormsFirebaseAuth.Features.Login
{
    public class ForgotPasswordViewModel : BaseViewModel
    {
        private string email;

        public ForgotPasswordViewModel()
        {
            ResetPasswordCommand = new Command(OnResetPassword);
        }

        private async void OnResetPassword(object obj)
        {
            try
            {

                var authService = DependencyService.Resolve<IAuthenticationService>();
                await authService.ResetPassword(Email);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Password Reset", "Password recovery sent, check your email", "OK");

                await Xamarin.Forms.Shell.Current
                    .GoToAsync("//LoginPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Password Reset", "An error occurs", "OK");
            }
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public ICommand ResetPasswordCommand { get; }
    }
}
