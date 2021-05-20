using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ShapeQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private double totalSum = 0;
        public ObservableCollection<Shape> Shapes { get; } = new();
        private void ValidateNumericInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9,]+").IsMatch(e.Text);
        }
        private void ButtonTriangle(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(triangleA.Text);
            double h = Convert.ToDouble(triangleH.Text);
            double triA = a * h / 2;
            totalSum += triA;
            sumField.Text = string.Format("{0:0.##}", totalSum);
            triangleA.Text = "";
            triangleH.Text = "";
            Shapes.Add(new Shape("Triangle", 0, a, h, triA));

        }

        private void ButtonCircle(object sender, RoutedEventArgs e)
        {
            double r = Convert.ToDouble(cireleR.Text);
            double cirA = Math.Pow(r, 2) * Math.PI;
            totalSum += cirA;
            sumField.Text = string.Format("{0:0.##}", totalSum);
            cireleR.Text = "";
            Shapes.Add(new Shape("Circle", r, 0, 0, cirA));
            
        }

        private void ButtonSquare(object sender, RoutedEventArgs e)
        {
            double a = Convert.ToDouble(squareA.Text);
            double b = Convert.ToDouble(squareB.Text);
            double squA = a * b;
            totalSum += squA;
            sumField.Text = string.Format("{0:0.##}", totalSum);
            squareA.Text = "";
            squareB.Text = "";
            Shapes.Add(new Shape("Square", 0, a, b, squA));
        }
    }
}
