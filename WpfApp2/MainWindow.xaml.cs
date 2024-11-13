using System;
using System.Windows;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private double _currentValue = 0;
        private double _lastValue = 0;
        private string _currentOperator = "";
        private bool _isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработка нажатия на кнопку с числом
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            string number = button.Content.ToString();

            if (_isNewEntry)
            {
                ResultTextBox.Text = number;
                _isNewEntry = false;
            }
            else
            {
                ResultTextBox.Text += number;
            }
        }

        // Обработка нажатия на кнопку с оператором
        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            var button = (System.Windows.Controls.Button)sender;
            string operatorSymbol = button.Content.ToString();

            _lastValue = double.Parse(ResultTextBox.Text);
            _currentOperator = operatorSymbol;
            _isNewEntry = true;
        }

        // Обработка нажатия на кнопку "="
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = double.Parse(ResultTextBox.Text);

            switch (_currentOperator)
            {
                case "+":
                    _currentValue = _lastValue + _currentValue;
                    break;
                case "-":
                    _currentValue = _lastValue - _currentValue;
                    break;
                case "×":
                    _currentValue = _lastValue * _currentValue;
                    break;
                case "÷":
                    if (_currentValue != 0)
                    {
                        _currentValue = _lastValue / _currentValue;
                    }
                    else
                    {
                        MessageBox.Show("Ошибка: деление на ноль");
                        _currentValue = 0;
                    }
                    break;
            }

            ResultTextBox.Text = _currentValue.ToString();
            _isNewEntry = true;
        }

        // Обработка нажатия на кнопку "C" (очистить)
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            _currentValue = 0;
            _lastValue = 0;
            _currentOperator = "";
            ResultTextBox.Text = "0";
            _isNewEntry = true;
        }
    }
}