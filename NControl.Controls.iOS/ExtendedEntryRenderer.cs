using Xamarin.Forms.Platform.iOS;
using UIKit;
using Xamarin.Forms;
using NControl.Controls;
using NControl.Controls.iOS;
using Simply.Core.Controls;

[assembly: ExportRenderer (typeof (ExtendedEntry), typeof (ExtendedEntryRenderer))]
namespace NControl.Controls.iOS
{
	public class ExtendedEntryRenderer: EntryRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="e">E.</param>
		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			var control = e.NewElement as ExtendedEntry;
			if (e.OldElement == null)
			{
				SetReturnType(control);

				Control.ShouldReturn += tf =>
				{
					if (control != null) control.InvokeCompleted();
					return true;
				};
			}

            if (Control != null && e.NewElement != null) 
			{
				var textfield = Control;
				textfield.BorderStyle = UITextBorderStyle.None;
                UpdateFont(control);
				
			}

			if (e.NewElement != null)
				UpdateTextAlignment ();
		}

		private void SetReturnType(ExtendedEntry entry)
		{
			switch (entry.ReturnType)
			{
				case ReturnType.Go:
					Control.ReturnKeyType = UIReturnKeyType.Go;
					break;
				case ReturnType.Next:
					Control.ReturnKeyType = UIReturnKeyType.Next;
					break;
				case ReturnType.Send:
					Control.ReturnKeyType = UIReturnKeyType.Send;
					break;
				case ReturnType.Search:
					Control.ReturnKeyType = UIReturnKeyType.Search;
					break;
				case ReturnType.Done:
					Control.ReturnKeyType = UIReturnKeyType.Done;
					break;
				default:
					Control.ReturnKeyType = UIReturnKeyType.Default;
					break;

			}
		}

		/// <summary>
		/// Raises the element property changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == ExtendedEntry.XAlignProperty.PropertyName)
				UpdateTextAlignment ();		
			else if (e.PropertyName == ExtendedEntry.FontFamilyProperty.PropertyName)
                UpdateFont (Element as ExtendedEntry);            
		}

		/// <summary>
		/// Updates the font.
		/// </summary>
        private void UpdateFont (ExtendedEntry element)
		{
            if (string.IsNullOrEmpty(element.FontFamily))
                return;
            
			Control.Font = UIFont.FromName (element.FontFamily, 
				Control.Font.PointSize);
		}

		/// <summary>
		/// Updates the text alignment.
		/// </summary>
		private void UpdateTextAlignment()
		{
			if (Control == null)
				return;
			
			Control.TextAlignment = ToUITextAlignment(((ExtendedEntry) Element).XAlign);
		}

		static UITextAlignment ToUITextAlignment(TextAlignment alignment)
		{
			switch (alignment)
			{
				case TextAlignment.Center:
					return UITextAlignment.Center;
				case TextAlignment.End:
					return UITextAlignment.Right;
				case TextAlignment.Start:
					return UITextAlignment.Left;
				default:
					return UITextAlignment.Natural;
			}
		}
	}
}

