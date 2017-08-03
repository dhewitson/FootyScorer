using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using System.Drawing;
using FootyScorer.UI.Controls;
using UIKit;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(FootyScorer.iOS.Renderers.RoundedBoxViewRenderer))]

namespace FootyScorer.iOS.Renderers
{
	public class RoundedBoxViewRenderer : ViewRenderer<RoundedBoxView, UIView>
	{
		private UIView _childView;

		protected override void OnElementChanged(ElementChangedEventArgs<RoundedBoxView> e)
		{
			base.OnElementChanged(e);

			var rbv = e.NewElement;
			if (rbv == null) return;

			var shadowView = new UIView();

			_childView = new UIView
			{
				BackgroundColor = rbv.Color.ToUIColor(),
				Layer =
				{
					CornerRadius = (float)rbv.CornerRadius,
					BorderColor = rbv.Stroke.ToCGColor(),
					BorderWidth = (float)rbv.StrokeThickness,
					MasksToBounds = true
				},
				AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight
			};

			shadowView.Add(_childView);

			if (rbv.HasShadow)
			{
				shadowView.Layer.ShadowColor = UIColor.Black.CGColor;
				shadowView.Layer.ShadowOffset = new SizeF(3, 3);
				shadowView.Layer.ShadowOpacity = 1;
				shadowView.Layer.ShadowRadius = 5;
			}

			SetNativeControl(shadowView);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName)
				_childView.Layer.CornerRadius = (float)Element.CornerRadius;
			else if (e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName)
				_childView.Layer.BorderColor = Element.Stroke.ToCGColor();
			else if (e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
				_childView.Layer.BorderWidth = (float)Element.StrokeThickness;
			else if (e.PropertyName == BoxView.ColorProperty.PropertyName)
				_childView.BackgroundColor = Element.Color.ToUIColor();
			else if (e.PropertyName == RoundedBoxView.HasShadowProperty.PropertyName)
			{
				if (Element.HasShadow)
				{
					NativeView.Layer.ShadowColor = UIColor.Black.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF(3, 3);
					NativeView.Layer.ShadowOpacity = 1;
					NativeView.Layer.ShadowRadius = 5;
				}
				else
				{
					NativeView.Layer.ShadowColor = UIColor.Clear.CGColor;
					NativeView.Layer.ShadowOffset = new SizeF();
					NativeView.Layer.ShadowOpacity = 0;
					NativeView.Layer.ShadowRadius = 0;
				}
			}
		}
	}
}