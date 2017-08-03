using FootyScorer.iOS.Renderers;
using FootyScorer.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TintedImage), typeof(TintedImageRenderer))]

namespace FootyScorer.iOS.Renderers
{
	public class TintedImageRenderer : ImageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
		{
			base.OnElementChanged(e);

			SetTint();
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == TintedImage.TintColorProperty.PropertyName)
				SetTint();
		}

		private void SetTint()
		{
			if (Control?.Image == null || Element == null) return;

			Control.Image = Control.Image.ImageWithRenderingMode(UIKit.UIImageRenderingMode.AlwaysTemplate);
			Control.TintColor = ((TintedImage)Element).TintColor.ToUIColor();
		}
	}
}