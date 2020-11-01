using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsFirebaseAuth.Features.Login
{
    public partial class ForgotPasswordPage : ContentPage
    {
        public ForgotPasswordPage()
        {
            InitializeComponent();

            BindingContext = new ForgotPasswordViewModel();
        }
    }
}
