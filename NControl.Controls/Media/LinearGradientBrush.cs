using System.Linq;
using NGraphics;
using Point = Xamarin.Forms.Point;

namespace NControl.Controls.Media
{
	public class LinearGradientBrush : BrushBase
	{
		public LinearGradientBrush()
		{
			StartPoint = new Point(0, 0);
			EndPoint = new Point(0, 1);
			GradientStops = new GradientStopCollection();
		}

		public GradientStopCollection GradientStops { get; set; }

		public Point StartPoint { get; set; }

		public Point EndPoint { get; set; }


		public override Brush ToNBrush()
		{
			return new NGraphics.LinearGradientBrush(
				StartPoint.ToNPoint(), 
				EndPoint.ToNPoint(), 
				GradientStops.Select(i => i.ToNGradientStop()).ToArray());
		}
	}
}
