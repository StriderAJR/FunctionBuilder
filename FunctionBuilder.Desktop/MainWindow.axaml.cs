using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using FunctionBuilder.Logic;

namespace FunctionBuilder.Desktop
{
	public class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
#if DEBUG
			this.AttachDevTools();
#endif
		}

		private void InitializeComponent()
		{
			AvaloniaXamlLoader.Load(this);
		}

		private void btnCalculate_Click(object sender, RoutedEventArgs e)
		{
			var spResult = this.FindControl<StackPanel>("spResult");
			var tbExpression = this.FindControl<TextBox>("tbExpression");
			var tbResult = this.FindControl<TextBlock>("tbResult");

			var expression = tbExpression.Text;
			var result = new Function(expression).ToString();

			spResult.IsVisible = true;
			tbResult.Text = result;
		}
	}
}
