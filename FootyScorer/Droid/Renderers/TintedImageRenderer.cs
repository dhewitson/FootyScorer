using Android.Graphics;
using FootyScorer.Droid.Renderers;
using System.ComponentModel;
using FootyScorer.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]

namespace FootyScorer.Droid.Renderers
{
	class TintedImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			SetTint();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == TintedImage.TintColorProperty.PropertyName)
				SetTint();
		}

		private void SetTint()
		{
			if (Control == null || Element == null) return;

			var colorFilter = new PorterDuffColorFilter(((TintedImage)Element).TintColor.ToAndroid(), PorterDuff.Mode.SrcIn);
			Control.SetColorFilter(colorFilter);
		}
	}
}