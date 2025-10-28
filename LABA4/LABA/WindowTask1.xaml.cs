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
using System.Windows.Shapes;

namespace LABA
{
    /// <summary>
    /// Interaction logic for WindowTask1.xaml
    /// </summary>
    public partial class WindowTask1 : Window
    {
        private double lastResult = 0;
        private string lastOperator = null;
        private bool isNewNumber = true;
        public WindowTask1()
        {
            InitializeComponent();
        }
        private void UpdateDisplay(string numberText, string expressionText)
        {
            Label2.Content = numberText;
            Label1.Content = expressionText;
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();
            string currentText = Label2.Content.ToString();

            if (isNewNumber)
            {
                if (digit == "0" && currentText == "0" && !currentText.Contains(","))
                {
                    return;
                }

                currentText = digit;
                isNewNumber = false;
            }
            else
            {
                if (currentText == "0" && digit != ".")
                {
                    currentText = digit;
                }
                else
                {
                    currentText += digit;
                }
            }
            UpdateDisplay(currentText, Label1.Content.ToString());
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            string currentText = Label2.Content.ToString();

            if (isNewNumber)
            {
                currentText = "0,";
                isNewNumber = false;
            }
            else if (!currentText.Contains(","))
            {
                currentText += ",";
            }
            UpdateDisplay(currentText, Label1.Content.ToString());
        }

        private void Operator_Click(object sender, RoutedEventArgs e)
        {
            string currentOperator = ((Button)sender).Content.ToString();
            double currentNumber = double.Parse(Label2.Content.ToString());

            if (lastOperator != null && !isNewNumber)
            {
                CalculateResult(currentNumber, false);
            }
            else if (lastOperator == null && !isNewNumber)
            {
                lastResult = currentNumber;
            }

            lastOperator = currentOperator;
            UpdateDisplay(Label2.Content.ToString(), $"{lastResult} {lastOperator}");

            isNewNumber = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (lastOperator == null) return;

            double currentNumber = double.Parse(Label2.Content.ToString());
            CalculateResult(currentNumber, true);

            UpdateDisplay(Label2.Content.ToString(), "");
            lastOperator = null;
            isNewNumber = true;
        }

        private void CalculateResult(double secondNumber, bool finalCalculation)
        {
            try
            {
                double result = lastResult;
                switch (lastOperator)
                {
                    case "+": result += secondNumber; break;
                    case "-": result -= secondNumber; break;
                    case "*": result *= secondNumber; break;
                    case "/":
                        if (secondNumber == 0) throw new DivideByZeroException();
                        result /= secondNumber; break;
                }

                lastResult = result;
                UpdateDisplay(result.ToString(), finalCalculation ? "" : Label1.Content.ToString());
            }
            catch (DivideByZeroException)
            {
                UpdateDisplay("Помилка: / 0", " ");
                lastResult = 0;
                lastOperator = null;
                isNewNumber = true;
            }
        }

        private void Control_Click(object sender, RoutedEventArgs e)
        {
            string buttonContent = ((Button)sender).Content.ToString();

            if (buttonContent == "C")
            {
                lastResult = 0;
                lastOperator = null;
                UpdateDisplay("0", "");
            }
            else
            {
                UpdateDisplay("0", Label1.Content.ToString());
            }
            isNewNumber = true;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            string currentText = Label2.Content.ToString();

            if (currentText.Length > 1 && currentText != "Помилка: / 0" && !isNewNumber)
            {
                currentText = currentText.Substring(0, currentText.Length - 1);
            }
            else
            {
                currentText = "0";
                isNewNumber = true;
            }
            UpdateDisplay(currentText, Label1.Content.ToString());
        }
    }

}
