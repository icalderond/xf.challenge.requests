using ServiceRequest.Views;
using Xamarin.Forms;

namespace ServiceRequest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (Device.RuntimePlatform == Device.UWP)
                MainPage = new DashboardPage();
            else
                MainPage = new RequestsPage();
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
