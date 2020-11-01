namespace XamFormsFirebaseAuth.Features.Shell
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = new AppShellViewModel();
        }
    }
}
