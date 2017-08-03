using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using FootyScorer.UI.Controls;

[assembly: ExportRenderer(typeof(RoundedBoxView), typeof(FootyScorer.Droid.Renderers.RoundedBoxViewRenderer))]
namespace FootyScorer.Droid.Renderers
{
	public class RoundedBoxViewRenderer : BoxRenderer
	{
		public RoundedBoxViewRenderer()
		{
			SetWillNotDraw(false);
		}

		public override void Draw(Canvas canvas)
		{
			var rbv = (RoundedBoxView)Element;

			var rc = new Rect();
			GetDrawingRect(rc);

			var interior = rc;
			interior.Inset((int)rbv.StrokeThickness, (int)rbv.StrokeThickness);

			var p = new Paint
			{
				Color = rbv.Color.ToAndroid(),
				AntiAlias = true,
			};

			canvas.DrawRoundRect(new RectF(interior), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);

			p.Color = rbv.Stroke.ToAndroid();
			p.StrokeWidth = (float)rbv.StrokeThickness;
			p.SetStyle(Paint.Style.Stroke);

			canvas.DrawRoundRect(new RectF(rc), (float)rbv.CornerRadius, (float)rbv.CornerRadius, p);
		}

		protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == RoundedBoxView.CornerRadiusProperty.PropertyName
				|| e.PropertyName == RoundedBoxView.StrokeProperty.PropertyName
				|| e.PropertyName == RoundedBoxView.StrokeThicknessProperty.PropertyName)
			{
				Invalidate();
			}
		}
	}
}
