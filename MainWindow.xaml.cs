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

namespace WPFCalculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      
        /// <summary>
        /// Деление
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            double operand1, operand2, result;
            //1 способ валидация через tryparse
            if (!double.TryParse(tbFirst.Text, out operand1))
            {
                MessageBox.Show("Первый операнд не число", "Контроль над вводом", MessageBoxButton.OK, MessageBoxImage.Error);
                tbFirst.Clear();
                tbFirst.Focus();
                return;
            }
            //2 способ валидация через обработку сбоя
            try
            {
                operand2 = Convert.ToDouble(tbSecord.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Второй операнд не число", "Контроль над вводом", MessageBoxButton.OK, MessageBoxImage.Error);
                tbSecord.Clear();
                tbSecord.Focus();
                return;
            }
            Button btn = e.Source as Button;
            switch (btn.Content.ToString())
            {
                case "+": result = operand1 + operand2;
                    break;
                case "-":
                    result = operand1 - operand2;
                    break;
                case "*":
                    result = operand1 * operand2;
                    break;
                case "/":
                    if (operand2 == 0)
                    {
                        MessageBox.Show("Нельзя делить на 0", "Контроль над вводом", MessageBoxButton.OK, MessageBoxImage.Error);
                        tbSecord.Clear();
                        tbSecord.Focus();
                        return;
                    }
                    result = operand1 / operand2;
                    break;
                case "x^y":
                    result = Math.Pow(operand1, operand2);
                    break;
                default: result= operand1;
                    break;
            }
            tbResult.Text = "Ответ: " + result;
        }
        private void btnClaer_Click(object sender, RoutedEventArgs e)
        {
            tbFirst.Clear();
            tbSecord.Clear();
            tbResult.Text = "Ответ: " + 0;
        }
    }
}
