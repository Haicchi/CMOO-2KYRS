using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for WindowTask2.xaml
    /// </summary>
    public partial class WindowTask2 : Window
    {
        private bool isInitialized = false;
        private double totalDay = 0;

        public WindowTask2()
        {
            InitializeComponent();
            isInitialized = true;
        }

        private void FuelComboBox(object sender, RoutedEventArgs e)
        {

            if (!isInitialized) return;

            if (Fuel.SelectedIndex == 0)
            {
                CostOfFuel.Text = "2.50";


            }
            else if (Fuel.SelectedIndex == 1)
            {
                CostOfFuel.Text = "3.00";


            }
            else if (Fuel.SelectedIndex == 2)
            {
                CostOfFuel.Text = "3.50";

            }
            CalculateFuelSum(null, null);
        }
        private void RadioCheck(object sender, RoutedEventArgs e)
        {
            if (!isInitialized) return;
            if (RadioCount.IsChecked == true)
            {
                FuelByCount.IsEnabled = true;
                FuelBySum.IsEnabled = false;
                FuelOrCash.Text = "До Оплати";
                ValueOrLiters.Text = "грн.";
            }
            else
            {
                FuelByCount.IsEnabled = false;
                FuelBySum.IsEnabled = true;
                FuelOrCash.Text = "До Видачі";
                ValueOrLiters.Text = "Літри";
            }
        }
        private void CalculateFuelSum(object sender, TextChangedEventArgs e)
        {
            if (!isInitialized) return;
            double costPerLiter;
            if (!double.TryParse(CostOfFuel.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out costPerLiter)) { costPerLiter = 0; }
            if (FuelByCount.IsEnabled)
            {
                if (double.TryParse(FuelByCount.Text, out double liters))
                {
                    double totalCost = liters * costPerLiter;
                    FuelResult.Text = totalCost.ToString("F2");
                }
                else
                {
                    FuelResult.Text = "0.00";
                }
            }
            else if (FuelBySum.IsEnabled)
            {
                if (double.TryParse(FuelBySum.Text, out double amount))
                {
                    double liters = amount / costPerLiter;
                    FuelResult.Text = liters.ToString("F2");
                }
                else
                {
                    FuelResult.Text = "0.00";
                }
            }
        }
        private void CafeCheckBox(object sender, RoutedEventArgs e)
        {
            if (!isInitialized) return;

            if (sender is CheckBox cb)
            {
                TextBox countBox = null;
                if (cb.Name == "HotDogCheck")
                {
                    countBox = HotDogCount;
                }
                else if (cb.Name == "HamburgerCheck")
                {
                    countBox = HamburgerCount;
                }
                else if (cb.Name == "FrenchFriesCheck")
                {
                    countBox = FrenchFriesCount;
                }
                else if (cb.Name == "CokeCheck")
                {
                    countBox = CokeCount;
                }
                if (countBox != null)
                {
                    if (cb.IsChecked == true)
                    {
                        countBox.IsEnabled = true;
                    }
                    else
                    {
                        countBox.IsEnabled = false;
                        countBox.Text = "0";
                    }

                }
                CafeSum(null, null);
            }
        }
        private void CafeSum(object sender, TextChangedEventArgs e)
        {
            
            if (!isInitialized) return;
            double cafeTotal = 0;
            if (sender is TextBox tb)
            {
                
                if (!double.TryParse(tb.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double count))
                {
                    MessageBox.Show($"Введіть коректне число для {tb.Name.Replace("Count", "")}.");
                    tb.Text = "0";
                }

            }
            if (HotDogCheck.IsChecked == true)
            {
                double count = 0;
                if (double.TryParse(HotDogCount.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out count))
                {
                    cafeTotal += count * 4.20;
                }
            }

            if (HamburgerCheck.IsChecked == true)
            {
                double count = 0;
                if (double.TryParse(HamburgerCount.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out count))
                {
                    cafeTotal += count * 10.00;
                }
            }

            if (FrenchFriesCheck.IsChecked == true)
            {
                double count = 0;
                if (double.TryParse(FrenchFriesCount.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out count))
                {
                    cafeTotal += count * 4.20;
                }
            }

            if (CokeCheck.IsChecked == true)
            {
                double count = 0;
                if (double.TryParse(CokeCount.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out count))
                {
                    cafeTotal += count * 4.20;
                }
            }

            CafeResult.Text = cafeTotal.ToString("F2");
            
        }
        private void FinalCalculation(object sender, RoutedEventArgs e)
        {
            if (!isInitialized) return;
            double fuelTotal = 0;
            double cafeTotal = 0;
            if (double.TryParse(FuelResult.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double ft))
            {
                fuelTotal = ft;
            }
            if (double.TryParse(CafeResult.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double ct))
            {
                cafeTotal = ct;
            }
            double total = fuelTotal + cafeTotal;
            totalDay+= total;
            ShowResult.Content = total.ToString("F2");
            DailyRevenue.Content = totalDay.ToString("F2");

        }
    }
}
