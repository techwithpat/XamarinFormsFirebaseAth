using System;
using System.Windows.Input;
using Xamarin.Forms;
using XamFormsFirebaseAuth.Features.Common;
using XamFormsFirebaseAuth.Framework;

namespace XamFormsFirebaseAuth.Features.Shell
{
    public class AppShellViewModel : BaseViewModel
    {
        public AppShellViewModel()
        {
            SignOutCommand = new Command(OnSignOut);
        }

        private void OnSignOut()
        {
            var authService = DependencyService.Resolve<IAuthenticationService>();
            authService.SignOut();

            Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
        }

        public ICommand SignOutCommand { get; }
    }
}
