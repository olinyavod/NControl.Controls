using Xamarin.Forms;

namespace NControl.Controls.Media
{
	public class GradientStop
	{
		public GradientStop()
		{
			
		}

		public GradientStop(Color color, float offset)
		{
			Color = color;
			Offset = offset;
		}

		public Color Color { get; set; }

		public float Offset { get; set; }
	}
}
