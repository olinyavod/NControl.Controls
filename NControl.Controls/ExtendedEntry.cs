/************************************************************************
 * 
 * The MIT License (MIT)
 * 
 * Copyright (c) 2025 - Christian Falch
 * 
 * Permission is hereby granted, free of charge, to any person obtaining 
 * a copy of this software and associated documentation files (the 
 * "Software"), to deal in the Software without restriction, including 
 * without limitation the rights to use, copy, modify, merge, publish, 
 * distribute, sublicense, and/or sell copies of the Software, and to 
 * permit persons to whom the Software is furnished to do so, subject 
 * to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be 
 * included in all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, 
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF 
 * MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. 
 * IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY 
 * CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
 * TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE 
 * SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 * 
 ************************************************************************/

using System;
using System.Windows.Input;
using Simply.Core.Controls;
using Xamarin.Forms;

namespace NControl.Controls
{
	/// <summary>
	/// Entry without borders
	/// </summary>
	public class ExtendedEntry: Entry
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NControl.Controls.ExtendedEntry"/> class.
		/// </summary>
		public ExtendedEntry ()
		{
			Completed += OnCompleted;
		}	

		/// <summary>
		/// The XAlign property.
		/// </summary>
		public static BindableProperty XAlignProperty = 
			BindableProperty.Create<ExtendedEntry, TextAlignment> (p => p.XAlign, 
				TextAlignment.Start, BindingMode.TwoWay,
				propertyChanged: (bindable, oldValue, newValue) => {
					var ctrl = (ExtendedEntry)bindable;
					ctrl.XAlign = newValue;
				});

		/// <summary>
		/// Gets or sets the XAlign of the ExtendedEntry instance.
		/// </summary>
		/// <value>The color of the buton.</value>
		public TextAlignment XAlign {
			get{ return (TextAlignment)GetValue (XAlignProperty); }
			set { SetValue(XAlignProperty, value); }
		}

		private void OnCompleted(object sender, EventArgs eventArgs)
		{
			InvokeCompleted();
		}

		public static readonly BindableProperty IsDoneProperty = BindableProperty.Create<ExtendedEntry, bool>(m => m.IsDone, false);

		public bool IsDone
		{
			get { return ((bool)GetValue(IsDoneProperty)); }
			set { SetValue(IsDoneProperty, value); }
		}

		public static readonly BindableProperty DoneCommandProperty = BindableProperty.Create<ExtendedEntry, ICommand>(m => m.DoneCommand, null);

		public ICommand DoneCommand
		{
			get { return ((ICommand)GetValue(DoneCommandProperty)); }
			set { SetValue(DoneCommandProperty, value); }
		}

		public static readonly BindableProperty DoneCommandParameterProperty = BindableProperty.Create<ExtendedEntry, object>(m => m.DoneCommandParameter, null);

		public object DoneCommandParameter
		{
			get { return GetValue(DoneCommandParameterProperty); }
			set { SetValue(DoneCommandParameterProperty, value); }
		}

		public static readonly BindableProperty ReturnTypeProperty = BindableProperty.Create<ExtendedEntry, ReturnType>(m => m.ReturnType, ReturnType.None);

		public ReturnType ReturnType
		{
			get { return ((ReturnType)GetValue(ReturnTypeProperty)); }
			set { SetValue(ReturnTypeProperty, value); }
		}

		public void InvokeCompleted()
		{
			if (DoneCommand != null && DoneCommand.CanExecute(DoneCommandParameter))
				DoneCommand.Execute(DoneCommandParameter);
		}
	}
}

