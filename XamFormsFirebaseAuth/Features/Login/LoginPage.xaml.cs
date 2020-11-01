using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsFirebaseAuth.Features.Login
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginViewModel();
        }
    }
}
