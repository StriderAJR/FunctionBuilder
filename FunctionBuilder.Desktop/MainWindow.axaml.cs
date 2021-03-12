using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using FunctionBuilder.Logic;
using MessageBox.Avalonia;
using System.Collections.Generic;
using System.Diagnostics;

namespace FunctionBuilder.Desktop
{
    public class MainWindow : Window
    {
        const string spResultName = "spResult";

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

        private void MainWindow_ContentRendered(object? sender, object e)
        {
            Draw();
        }

        private void Draw()
        {
            var canvas = this.FindControl<Canvas>("canvas");
            var dpCanvas = this.FindControl<DockPanel>("dpCanvas");
            var border = this.FindControl<Border>("borderCanvas");

            Debug.WriteLine(canvas.DesiredSize.Height);
            Debug.WriteLine(canvas.DesiredSize.Width);

            var xAxis = new Line();
            var height = canvas.DesiredSize.Height;
            var width = canvas.DesiredSize.Width;

            xAxis.StartPoint = new Point(0, height / 2);
            xAxis.EndPoint = new Point(100, height / 2);
            xAxis.Stroke = new SolidColorBrush(Color.Parse("black"));
            xAxis.StrokeThickness = 1;

            canvas.Children.Add(xAxis);

            //var newEllipse = new Ellipse();
            //var brush = new SolidColorBrush(Color.Parse("red"));
            //newEllipse.Fill = brush;
            //newEllipse.Width = 50;
            //newEllipse.Height = 50;

            //var line = new Line();
            //line.StartPoint = new Point(100, 100);
            //line.EndPoint = new Point(150, 150);
            //line.Stroke = new SolidColorBrush(Color.Parse("black"));
            //line.StrokeThickness = 1;

            //var polyline = new Polyline();
            //polyline.Points = new List<Point> { new Point(0, 0), new Point(10, 10), new Point(15, 50), new Point(50, 80), new Point(200, 200) };
            //polyline.Stroke = new SolidColorBrush(Color.Parse("orange"));

            //canvas.Children.Add(newEllipse);
            //canvas.Children.Add(line);
            //canvas.Children.Add(polyline);
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            var spRPN = this.FindControl<StackPanel>("spRPN");
            var spResult = this.FindControl<StackPanel>(spResultName);
            var tbExpression = this.FindControl<TextBox>("tbExpression");
            var tbResult = this.FindControl<TextBlock>("tbResult");
            var tbRPN = this.FindControl<TextBlock>("tbRPN");

            var expression = tbExpression.Text;
            var function = new Function(expression);

            spResult.IsVisible = true;
            spRPN.IsVisible = true;

            tbRPN.Text = function.ToString();
            tbResult.Text = function.Calculate().ToString();
        }

        private void Canvas_KeyDown(object sender, PointerPressedEventArgs e)
        {
            var mb = MessageBoxManager
                    .GetMessageBoxStandardWindow("title", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed...");
                mb.Show();
        }
    }
}
