using Android.Views.InputMethods;
using Android.Widget;
using FootyScorer.Droid.Renderers;
using FootyScorer.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryWithHandler), typeof(ExtendedEntryWithHandlerRenderer))]
namespace FootyScorer.Droid.Renderers
{
	public class ExtendedEntryWithHandlerRenderer : ExtendedEntryRenderer
	{
		private new EntryWithHandler Element => (EntryWithHandler)base.Element;

		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			//Unhooked in dispose
			Control.EditorAction += HandleNextAction;
		}

		private void HandleNextAction(object sender, TextView.EditorActionEventArgs e)
		{
			e.Handled = false;
			if (e.ActionId == ImeAction.Next && NextElement != null)
			{
				NextElement?.Focus();
				e.Handled = true;
			}

			if (!e.Handled)
				Element.PressEnter();
		}
	}
}
