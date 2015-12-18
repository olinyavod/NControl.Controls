using System;
using System.Globalization;
using Xamarin.Forms;

namespace NControl.Controls.Media
{
	public class GradientStopCollectionTypeConverter:TypeConverter
	{
		public override bool CanConvertFrom(Type sourceType)
		{
			if(sourceType == null)
				throw new ArgumentNullException("sourceType");
			return sourceType == typeof (string);
		}

		public override object ConvertFrom(CultureInfo culture, object value)
		{
			if (value == null)
				return null;
			var input = value as string;
			if (input == null)
				throw new InvalidOperationException(string.Format("Cannot convert \"{0}\" into {1}", value, typeof(Color)));
			var splits = input.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
			var result = new GradientStopCollection();
			var colorTypeConverter = new ColorTypeConverter();
			GradientStop item = null;
			for (int i = 0; i < splits.Length; i++)
			{
				if (i == 0 || i % 2 == 0) {
					item = new GradientStop (((Color)colorTypeConverter.ConvertFrom (culture, splits [i])), 0);
					result.Add (item);
				}
				else
				{
					float offset;
					float.TryParse(splits[i], NumberStyles.Number, CultureInfo.InvariantCulture, out offset);
					if (item != null) item.Offset = offset;
				}
			}
			return result;

		}
	}
}
