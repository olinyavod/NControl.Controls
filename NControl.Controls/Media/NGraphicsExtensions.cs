namespace NControl.Controls.Media
{
	public static class NGraphicsExtensions
	{
		public static NGraphics.Point ToNPoint(this Xamarin.Forms.Point point)
		{
			return new NGraphics.Point(point.X, point.Y);
		}

		public static NGraphics.GradientStop ToNGradientStop(this GradientStop gradientStop)
		{
			return new NGraphics.GradientStop(gradientStop.Offset, gradientStop.Color.ToNColor());
		}

		public static Xamarin.Forms.Rectangle ToXamRect(this NGraphics.Rect rect)
		{
			return new Xamarin.Forms.Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
		}

		public static NGraphics.Rect ToNRect(this Xamarin.Forms.Rectangle rect)
		{
			return new NGraphics.Rect(rect.X, rect.Y, rect.Width, rect.Height);
		}
	}
}
