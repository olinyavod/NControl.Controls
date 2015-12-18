using NGraphics;
using Color = Xamarin.Forms.Color;

namespace NControl.Controls.Media
{
	public class ColorSolidBrush:BrushBase
	{
		public ColorSolidBrush()
		{
			
		}

		public ColorSolidBrush(Color color)
		{
			Color = color;
		}
		public Color Color { get; set; }
		
		public override Brush ToNBrush()
		{
			return new SolidBrush(Color.ToNColor());
		}
	}
}
