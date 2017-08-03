using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
	public class RoundedBoxView : BoxView
	{
		public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(RoundedBoxView), default(double));
		public static readonly BindableProperty HasShadowProperty = BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(RoundedBoxView), false);
		public static readonly BindableProperty StrokeProperty = BindableProperty.Create(nameof(Stroke), typeof(Color), typeof(RoundedBoxView), Color.Transparent);
		public static readonly BindableProperty StrokeThicknessProperty = BindableProperty.Create(nameof(StrokeThickness), typeof(double), typeof(RoundedBoxView), default(double));

        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
		public double CornerRadius
		{
			get { return (double)GetValue(CornerRadiusProperty); }
			set { SetValue(CornerRadiusProperty, value); }
		}

        /// <summary>
        /// Gets or sets the stroke colour.
        /// </summary>
        /// <value>The stroke.</value>
		public Color Stroke
		{
			get { return (Color)GetValue(StrokeProperty); }
			set { SetValue(StrokeProperty, value); }
		}

        /// <summary>
        /// Gets or sets the stroke thickness.
        /// </summary>
        /// <value>The stroke thickness.</value>
		public double StrokeThickness
		{
			get { return (double)GetValue(StrokeThicknessProperty); }
			set { SetValue(StrokeThicknessProperty, value); }
		}

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:FootyScorer.UI.Controls.RoundedBoxView"/> has shadow.
        /// </summary>
        /// <value><c>true</c> if has shadow; otherwise, <c>false</c>.</value>
		public bool HasShadow
		{
			get { return (bool)GetValue(HasShadowProperty); }
			set { SetValue(HasShadowProperty, value); }
		}
	}
}