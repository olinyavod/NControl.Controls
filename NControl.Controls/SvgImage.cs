using System;
using System.IO;
using System.Reflection;
using NControl.Abstractions;
using NGraphics;
using Xamarin.Forms;

namespace NControl.Controls
{
	public class SvgImage : NControlView
	{
		public SvgImage()
		{
			SizeChanged += OnSizeChanged;
			var declaredMethod = typeof(Assembly).GetTypeInfo().GetDeclaredMethod("GetCallingAssembly");
			if (declaredMethod != null)
			{
				SvgAssembly = (Assembly)declaredMethod.Invoke((object)null, new object[0]);
			}
		}

		private void OnSizeChanged(object sender, EventArgs eventArgs)
		{
			Invalidate();
		}


		private Graphic _svgGraphic;

		public static readonly BindableProperty SvgProperty = BindableProperty.Create<SvgImage, string>(i => i.Svg, null, BindingMode.OneWay, null, SvgPropertyChanged);

		private static void SvgPropertyChanged(BindableObject bindable, string oldValue, string newValue)
		{
			var control = (SvgImage) bindable;
			control.ChangeSource();
		}

		void ChangeSource()
		{
			if (!string.IsNullOrEmpty(Svg) && SvgAssembly != null)
			{
				using (var stream = SvgAssembly.GetManifestResourceStream(Svg))
				{
					var reader = new SvgReader(new StreamReader(stream));
					_svgGraphic = reader.Graphic;
				}
				Invalidate();
			}
		}

		public string Svg
		{
			get { return ((string) GetValue(SvgProperty)); }
			set { SetValue(SvgProperty, value); }
		}

		public static readonly BindableProperty SvgAssemblyProperty = BindableProperty.Create<SvgImage, Assembly>(i => i.SvgAssembly, null, BindingMode.OneWay, null, SvgAssemblyPropertyChanged);

		private static void SvgAssemblyPropertyChanged(BindableObject bindable, Assembly oldValue, Assembly newValue)
		{
			var control = (SvgImage)bindable;
			control.ChangeSource();
		}

		public Assembly SvgAssembly
		{
			get { return ((Assembly) GetValue(SvgAssemblyProperty)); }
			set { SetValue(SvgAssemblyProperty, value); }
		}

		public override void Draw(ICanvas canvas, Rect rect)
		{
			base.Draw(canvas, rect);
			if (_svgGraphic == null)
				return;
			canvas.SaveState();
			var sx = 1.0;
			if (_svgGraphic.ViewBox.Width > 0.0)
				sx = rect.Width / _svgGraphic.ViewBox.Width;
			var sy = 1.0;
			if (_svgGraphic.ViewBox.Height > 0.0)
				sy = rect.Height / _svgGraphic.ViewBox.Height;

			var scale = Math.Min(sy, sx);
			canvas.Scale(scale);
			var tranX = -_svgGraphic.ViewBox.X;
			if (rect.Width/scale > _svgGraphic.ViewBox.Width)
			{
				tranX = (rect.Width/scale - _svgGraphic.ViewBox.Width)/2;
			}
			var tranY = -_svgGraphic.ViewBox.Y;
			if (rect.Height/scale > _svgGraphic.ViewBox.Height)
			{
				tranY = (rect.Height/scale - _svgGraphic.ViewBox.Height)/2;
			}
			canvas.Translate(tranX, tranY);
			foreach (IDrawable drawable in _svgGraphic.Children)
				drawable.Draw(canvas);
			canvas.RestoreState();

		}
	}
}
