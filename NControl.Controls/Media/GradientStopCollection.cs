using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace NControl.Controls.Media
{
	[TypeConverter(typeof(GradientStopCollectionTypeConverter))]
	public class GradientStopCollection : Collection<GradientStop>
	{
	}
}
