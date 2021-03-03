using FunctionBuilder.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FunctionBuilder.WPF
{
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
            var expression = tbExpression.Text;
            var function = new Function(expression);

            spResult.Visibility = Visibility.Visible;
            spRPN.Visibility = Visibility.Visible;

            tbRPN.Text = function.ToString();
            tbResult.Text = function.Calculate().ToString();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Draw();
        }

        private void Draw()
        {
            canvas.Children.Clear();

            var xAxis = new Line();
            var height = canvas.ActualHeight;
            var width = canvas.ActualWidth;

            xAxis.X1 = 0;
            xAxis.Y1 = height / 2;
            xAxis.X2 = width;
            xAxis.Y2 = height / 2;
            xAxis.Stroke = Brushes.Black;
            xAxis.StrokeThickness = 1;

            canvas.Children.Add(xAxis);
        }
    }
}
