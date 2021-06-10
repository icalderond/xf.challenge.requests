using Android.Content;
using Android.Graphics.Drawables;
using ServiceRequest.Droid.Renderers;
using ServiceRequest.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSearchBar), typeof(CustomSearchBarDroid))]
namespace ServiceRequest.Droid.Renderers
{
    public class CustomSearchBarDroid : EntryRenderer
    {
        public CustomSearchBarDroid(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
                this.Control.SetPadding(0, 0, 0, 0);
                this.Control.Background = gd;
            }
        }
    }
}