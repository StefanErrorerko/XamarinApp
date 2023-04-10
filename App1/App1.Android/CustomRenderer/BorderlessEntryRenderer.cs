using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App1.CustomRenderer;
using App1.Droid.CustomRenderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace App1.Droid.CustomRenderer
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Black);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Transparent);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

                Control.SetTextCursorDrawable(Resource.Drawable.cursor);
            }
        }
    }
}