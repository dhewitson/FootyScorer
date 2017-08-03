using System;
using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
	public class EntryWithHandler : Entry
	{
		public event EventHandler EnterPressed;
		public void PressEnter()
		{
			EnterPressed?.Invoke(this, new EventArgs());
		}
	}
}
