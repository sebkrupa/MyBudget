using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MyBudget_Core.View.Statistics
{
    /// <summary>
    /// Interaction logic for AverageExpenditure.xaml
    /// </summary>
    public partial class AverageMonthly : UserControl
    {
        private bool hideAdd = false;
        int yearsBack = 5;

        public AverageMonthly()
        {
            InitializeComponent();
            btnAdd.Click += AddMonthly;
        }

        private void AddMonthly(object sender, RoutedEventArgs e)
        {
            if (checkCategoriesOnly.IsChecked.Value)
            {
                if (categoryPicker.cbxCategory.SelectedItem != null)
                {
                    var selectedCategory = (MyBudgetAPI.Model.Category)categoryPicker.cbxCategory.SelectedItem;
                    mainChart.AddToChart(selectedCategory.name, ViewModel.Statistics.GetCategoryExpensesMonthly(selectedCategory.id));
                }
            }
            else
            {
                if (categoryPicker.cbxSubCategory.SelectedItem != null)
                {
                    var selectedSubCategory = (MyBudgetAPI.Model.SubCategory)categoryPicker.cbxSubCategory.SelectedItem;
                    mainChart.AddToChart(selectedSubCategory.name, ViewModel.Statistics.GetSubCategoryExpensesMonthly(selectedSubCategory.id));
                }
            }
        }

        private void AddYearly(object sender, RoutedEventArgs e)
        {
            if (checkCategoriesOnly.IsChecked.Value)
            {
                if (categoryPicker.cbxCategory.SelectedItem != null)
                {
                    var selectedCategory = (MyBudgetAPI.Model.Category)categoryPicker.cbxCategory.SelectedItem;
                    mainChart.AddToChart(selectedCategory.name, ViewModel.Statistics.GetCategoryExpensesYearly(selectedCategory.id, yearsBack));
                }
            }
            else
            {
                if (categoryPicker.cbxSubCategory.SelectedItem != null)
                {
                    var selectedSubCategory = (MyBudgetAPI.Model.SubCategory)categoryPicker.cbxSubCategory.SelectedItem;
                    mainChart.AddToChart(selectedSubCategory.name, ViewModel.Statistics.GetSubCategoryExpensesYearly(selectedSubCategory.id, yearsBack));
                }
            }
        }

        private void Button_RemoveFromChart(object sender, RoutedEventArgs e)
        {
            var selectedSubCategory = (MyBudgetAPI.Model.SubCategory)categoryPicker.cbxSubCategory.SelectedItem;
            mainChart.RemoveFromChart(selectedSubCategory.name);
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e) => ((TextBlock)sender).Background = Brushes.LightBlue;

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e) => ((TextBlock)sender).Background = Brushes.Transparent;

        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            hideAdd = !hideAdd;
            if (hideAdd)
            {
                panelAdd.Height = new GridLength(0);
                txtHide.Text = "^";
            }
            else
            {
                panelAdd.Height = new GridLength(1, GridUnitType.Star);
                txtHide.Text = "v";
            }
        }

        private void checkCategoriesOnly_Click(object sender, RoutedEventArgs e) => categoryPicker.cbxSubCategory.IsEnabled = !((CheckBox)sender).IsChecked.Value;

        private void radioMonth_Click(object sender, RoutedEventArgs e)
        {
            mainChart.RemoveAllFromChart();
            mainChart.SetXLabels_Months();
            btnAdd.Click -= AddYearly;
            btnAdd.Click += AddMonthly;
        }

        private void radioYear_Click(object sender, RoutedEventArgs e)
        {
            mainChart.RemoveAllFromChart();
            List<string> years = new List<string>();
            for (int i = yearsBack - 1; i >= 0; i--)
                years.Add((DateTime.Now.Year - i).ToString());
            mainChart.SetXLabels_Years(years.ToArray());
            btnAdd.Click -= AddMonthly;
            btnAdd.Click += AddYearly;
        }
    }
}
