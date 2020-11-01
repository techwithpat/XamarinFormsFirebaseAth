
using Xamarin.Forms;

namespace XamFormsFirebaseAuth.Features.Login
{
    public partial class NewUserPage : ContentPage
    {
        public NewUserPage()
        {
            InitializeComponent();

            BindingContext = new NewUserViewModel();
        }
    }
}
