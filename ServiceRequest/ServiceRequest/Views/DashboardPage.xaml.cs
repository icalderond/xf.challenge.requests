using ServiceRequest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ServiceRequest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardPage : ContentPage
    {
        public DashboardPage()
        {
            InitializeComponent();
            //this.BindingContext = new DashboardViewModel();
        }
    }
}