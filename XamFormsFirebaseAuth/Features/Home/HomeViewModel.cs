using System;
using Xamarin.Forms;
using XamFormsFirebaseAuth.Features.Common;
using XamFormsFirebaseAuth.Framework;

namespace XamFormsFirebaseAuth.Features.Home
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {            
            CheckWhetherTheUserIsSignIn();
        }

        private async void CheckWhetherTheUserIsSignIn()
        {
            try
            {
                var authenticationService = DependencyService.Resolve<IAuthenticationService>();
                if (!authenticationService.IsSignIn())
                    await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);               
            }           
        }
    }
}
