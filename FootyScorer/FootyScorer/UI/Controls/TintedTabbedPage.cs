using Xamarin.Forms;
namespace FootyScorer.UI.Controls
{
	public class TintedTabbedPage : TabbedPage
	{
        public static readonly BindableProperty TintProperty = BindableProperty.Create(nameof(Tint), typeof(Color), typeof(TintedTabbedPage), Color.Transparent);

        /// <summary>
        /// Gets or sets the tint colour.
        /// </summary>
        /// <value>The tint.</value>
		public Color Tint
		{
			get { return (Color)GetValue(TintProperty); }
			set { SetValue(TintProperty, value); }
		}
	}
}
