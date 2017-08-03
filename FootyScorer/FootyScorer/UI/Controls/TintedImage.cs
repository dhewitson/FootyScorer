﻿using Xamarin.Forms;

namespace FootyScorer.UI.Controls
{
	public class TintedImage : Image
	{
		public static readonly BindableProperty TintColorProperty = BindableProperty.Create(nameof(TintColor), typeof(Color), typeof(TintedImage), Color.Transparent);

		public Color TintColor
		{
			get { return (Color)GetValue(TintColorProperty); }
			set { SetValue(TintColorProperty, value); }
		}
	}
}
