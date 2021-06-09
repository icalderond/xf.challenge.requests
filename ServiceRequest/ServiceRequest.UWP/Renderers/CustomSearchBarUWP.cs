using ServiceRequest.Renderers;
using ServiceRequest.UWP.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;


[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarUWP))]
namespace ServiceRequest.UWP.Renderers
{
    public class CustomSearchBarUWP : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(0);
                Control.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Colors.Transparent);
            }
        }
    }
}
