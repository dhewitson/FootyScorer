using FootyScorer.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(TintedTabbedPage), typeof(FootyScorer.iOS.Renderers.TintedTabbedPageRenderer))]
namespace FootyScorer.iOS.Renderers
{
	public class TintedTabbedPageRenderer : TabbedRenderer
	{
		public TintedTabbedPageRenderer()
		{
            TabBar.TintColor = ((TintedTabbedPage)Element).Tint.ToUIColor();
		}
	}
}