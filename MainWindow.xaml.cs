using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using Triangles.Models;

namespace Triangles
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Triangle ctx;

        public MainWindow()
        {
            ctx = new Triangle();

            InitializeComponent();
            DataContext = ctx;
        }

        private void ValidateIsInt(object sender, TextCompositionEventArgs e)
        {
            // only allow integers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
