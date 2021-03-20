using System.Collections.Generic;
using FunctionBuilder.Logic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace FunctionBuilder.WPF
{
    public class FunctionValue
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string expression = tbExpression.Text;
            double rangeStart = string.IsNullOrEmpty(tbRangeStart.Text) ? double.NaN : double.Parse(tbRangeStart.Text);
            double rangeEnd = string.IsNullOrEmpty(tbRangeEnd.Text) ? double.NaN : double.Parse(tbRangeEnd.Text);
            double delta = string.IsNullOrEmpty(tbDelta.Text) ? double.NaN : double.Parse(tbDelta.Text);

            Function function = new Function(expression, rangeStart, rangeEnd, delta);
            Dictionary<double, double> functionValues = function.CalculateFunctionValues();

            spRPN.Visibility = Visibility.Visible;
            tbRPN.Text = function.ToString();

            if (functionValues.Count == 1)
            {
                spResult.Visibility = Visibility.Visible;
                tbResult.Text = function.CalculateFunctionValues().First().Value.ToString();
            }
            else
            {
                gFunctionValues.Visibility = Visibility.Visible;
                gFunctionValues.ItemsSource = functionValues.Select(x => new FunctionValue { X = x.Key, Y = x.Value }).ToList();
            }
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            canvas.Children.Clear();

            Line xAxis = new Line();
            double height = canvas.ActualHeight;
            double width = canvas.ActualWidth;

            xAxis.X1 = 0;
            xAxis.Y1 = height / 2;
            xAxis.X2 = width;
            xAxis.Y2 = height / 2;
            xAxis.Stroke = Brushes.Red;
            xAxis.StrokeThickness = 2;

            Polygon arrow1 = new Polygon();
            arrow1.Points.Add(new Point(height / 2, width));
            arrow1.Points.Add(new Point(height / 2 - 10, width - 15));
            arrow1.Points.Add(new Point(height / 2 + 10, width - 15));
            arrow1.Fill = Brushes.Black;

            arrow1.MouseUp += arrow1_MouseUp;

            canvas.Children.Add(xAxis);
            canvas.Children.Add(arrow1);
        }

        private void arrow1_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TestWindow testWindow = new TestWindow();
            testWindow.Show();
        }
    }
}
