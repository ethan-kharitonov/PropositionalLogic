using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfMath.Converters;
using WpfMath;

namespace Display
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly TexFormulaParser formulaParser = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private TexFormula? ParseFormula(string input)
        {
            // Create formula object from input text.
            TexFormula? formula = null;
            try
            {
                formula = formulaParser.Parse(input);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while parsing the given input:" + Environment.NewLine +
                    Environment.NewLine + ex.Message, "WPF-Math Example", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return formula;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //
        }

        private void InputTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Formula.SelectionStart = InputTextBox.SelectionStart;
            Formula.SelectionLength = InputTextBox.SelectionLength;
        }

        private void FormulaTextBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            InputTextBox.Text = (string)item.DataContext;
        }
    }
}
