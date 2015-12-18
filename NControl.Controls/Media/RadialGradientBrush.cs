using NGraphics;
using Point = Xamarin.Forms.Point;

namespace NControl.Controls.Media
{
	public class RadialGradientBrush:BrushBase
	{
		public RadialGradientBrush()
		{
			CenterPoint = new Point(0.5, 0.5);
			Radius = 1;
		}

		public Xamarin.Forms.Color StartColor { get; set; }

		public Xamarin.Forms.Color EndColor { get; set; }
		
		public Point CenterPoint { get; set; }

		public float Radius { get; set; }


		public override Brush ToNBrush()
		{
			return new NGraphics.RadialGradientBrush(CenterPoint.ToNPoint(),
				new Size(Radius), 
				StartColor.ToNColor(),
				EndColor.ToNColor());
		}

		
	}
}
