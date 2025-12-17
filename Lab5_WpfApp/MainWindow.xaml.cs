using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Lab5_WpfApp.Models;

namespace Lab5_WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (RadioFrac == null || RadioComplex == null || GroupSort == null) return;
            TextResult.Text = "";
            InputA.Text = "";
            InputB.Text = "";
            if (RadioFrac.IsChecked == true)
            {
                HintA.Text = "e.g. '1/2', '1 3/4', '-5'";
                HintB.Text = "e.g. '2/3', '5'";
                GroupSort.Visibility = Visibility.Visible;
            }
            else
            {
                HintA.Text = "e.g. '3+4i', '5', '-i'";
                HintB.Text = "e.g. '1-2i'";
                GroupSort.Visibility = Visibility.Collapsed;
            }
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            string op = (sender as Button)?.Tag.ToString();
            string txtA = InputA.Text;
            string txtB = InputB.Text;

            try
            {
                if (RadioFrac.IsChecked == true)
                {
                    MyFrac a = new MyFrac(txtA);
                    MyFrac b = new MyFrac(txtB);
                    MyFrac res = null;

                    switch (op)
                    {
                        case "Add": res = a + b; break;
                        case "Sub": res = a - b; break;
                        case "Mul": res = a * b; break;
                        case "Div": res = a / b; break;
                    }
                    TextResult.Text = res.ToString();
                }
                else
                {
                    MyComplex a = new MyComplex(txtA);
                    MyComplex b = new MyComplex(txtB);
                    MyComplex res = null;

                    switch (op)
                    {
                        case "Add": res = a + b; break;
                        case "Sub": res = a - b; break;
                        case "Mul": res = a * b; break;
                        case "Div": res = a / b; break;
                    }
                    TextResult.Text = res.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSort_Click(object sender, RoutedEventArgs e)
        {
            string input = InputSort.Text;

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please enter a list of fractions.", "Input Empty");
                return;
            }

            try
            {
                var parts = input.Split([',', ' ', ';'], StringSplitOptions.RemoveEmptyEntries);
                List<MyFrac> list = new List<MyFrac>();

                foreach (var part in parts)
                {
                    list.Add(new MyFrac(part));
                }

                if (list.Count == 0) return;

                list.Sort();

                string resultStr = string.Join("  <  ", list);
                TextResult.Text = resultStr;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Parsing Error: {ex.Message}\nMake sure to enter valid fractions like '1/2' or '5'.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}