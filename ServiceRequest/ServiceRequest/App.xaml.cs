using ServiceRequest.Views;
using Xamarin.Forms;

namespace ServiceRequest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Device.Idiom==TargetIdiom.Phone)
                MainPage = new RequestsPage();
            else
                MainPage = new DashboardPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
