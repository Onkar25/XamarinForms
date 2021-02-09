
using System;
using HouseOfTrader.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(MyDatePickerRenderer))]
namespace HouseOfTrader.iOS.Renderers
{
    public class MyDatePickerRenderer : DatePickerRenderer
    {
        public MyDatePickerRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && this.Control != null)
            {
                try
                {
                    if (UIDevice.CurrentDevice.CheckSystemVersion(13, 2))
                    {
                        UIDatePicker picker = (UIDatePicker)Control.InputView;
                        picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
                    }
                }
                catch (Exception)
                {
                    // do nothing
                }
            }
        }
    }
}
