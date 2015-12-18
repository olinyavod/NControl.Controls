using NControl.Abstractions;
using NControl.Controls.Media;
using NGraphics;
using Xamarin.Forms;
using Color = Xamarin.Forms.Color;


namespace NControl.Controls
{
	public class BackgroundPanel:NControlView
	{
		public readonly static BindableProperty BackgroundBrushProperty = BindableProperty.Create<BackgroundPanel, BrushBase>(p => p.BackgroundBrush, null, BindingMode.OneWay, null, BackgroundBrushPropertyChanged);

		private static void BackgroundBrushPropertyChanged(BindableObject bindable, BrushBase oldValue, BrushBase newValue)
		{
			var control = (BackgroundPanel) bindable;
			control.Invalidate();
		}

		public readonly static BindableProperty BorderColorProperty = BindableProperty.Create<BackgroundPanel, Color?>(p => p.BorderColor, null, BindingMode.OneWay, null, BorderColorPropertyChanged);

		private static void BorderColorPropertyChanged(BindableObject bindable, Color? oldValue, Color? newValue)
		{
			var control = (BackgroundPanel) bindable;
			control.Invalidate();
		}

		public Color? BorderColor
		{
			get { return ((Color?) GetValue(BorderColorProperty)); }
			set { SetValue(BorderColorProperty, value); }
		}

		public BrushBase BackgroundBrush
		{
			get { return ((BrushBase) GetValue(BackgroundBrushProperty)); }
			set { SetValue(BackgroundBrushProperty, value);}
		}



		public override void Draw(ICanvas canvas, Rect rect)
		{
			base.Draw(canvas, rect);
			canvas.DrawRectangle(rect, CreateBorderPen(), CreateBackgroundBrush(rect));
			
		}

		protected Pen CreateBorderPen()
		{
			return BorderColor != null ? new Pen(BorderColor.GetValueOrDefault().ToNColor()) : null;
		}

		protected Brush CreateBackgroundBrush(Rect rect)
		{
			return BackgroundBrush != null ? BackgroundBrush.ToNBrush() : null;
		}
	}
}
