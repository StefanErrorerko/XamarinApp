using Android.Content;
using App1;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

public class TodoBoxRenderer : Xamarin.Forms.Platform.Android.CheckBoxRenderer
{
    public TodoBoxRenderer(Context context) : base(context) { }

    protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
    {
        base.OnElementChanged(e);
    }
}