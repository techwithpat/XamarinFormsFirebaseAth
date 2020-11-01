using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamFormsFirebaseAuth.Features.Home
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel();
        }
    }
}
