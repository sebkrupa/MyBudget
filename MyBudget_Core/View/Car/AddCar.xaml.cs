using System;
using System.Windows;
using System.Windows.Controls;

namespace MyBudget_Core.View.Car
{
    /// <summary>
    /// Interaction logic for AddCar.xaml
    /// </summary>
    public partial class AddCar : UserControl
    {
        public AddCar()
        {
            InitializeComponent();
            datePicker.SelectedDate = DateTime.Now;
        }

        /// <summary>
        /// dodaje nowy wpis do paliwa oraz do wydatków pod domyślnym subcategory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            if (FieldsAreFilled())
            {
                try
                {
                    var newCar = new MyBudgetAPI.Model.Car()
                    {
                        comment = txtComment.Text,
                        date = datePicker.SelectedDate.Value.ToShortDateString(),
                        kmCounter = Convert.ToDouble(txtKmCounter.Text),
                        litres = Convert.ToDouble(txtLitres.Text),
                        paid = Convert.ToDouble(txtPaid.Text),
                        station = txtStation.Text
                    };
                    var newExpenditure = new MyBudgetAPI.Model.Expenses()
                    {
                        comment = txtComment.Text,
                        date = datePicker.SelectedDate.Value.ToShortDateString(),
                        subCategoryId = DBSettings.Default.FuelSubCategory,
                        value = Convert.ToDouble(txtPaid.Text),
                    };

                    new MyBudgetAPI.Create.Car().Add(newCar);
                    new MyBudgetAPI.Create.Expenses().Add(newExpenditure);
                    ClearFields();
                    RefreshParenTable();
                }
                catch (Exception)
                {
                    MessageBox.Show("Wystąpił błąd podczas wprowadzania danych");
                }
            }
        }

        private bool FieldsAreFilled()
        {
            if (string.IsNullOrWhiteSpace(txtKmCounter.Text) ||
                string.IsNullOrWhiteSpace(txtLitres.Text) ||
                string.IsNullOrWhiteSpace(txtPaid.Text) ||
                string.IsNullOrWhiteSpace(txtStation.Text) ||
                datePicker.SelectedDate == null ||
                DBSettings.Default.FuelSubCategory == 0)
                return false;
            return true;
        }

        private void ClearFields()
        {
            txtKmCounter.Text = txtLitres.Text = txtPaid.Text = txtStation.Text = txtComment.Text = string.Empty;
            datePicker.SelectedDate = DateTime.Now;
        }

        private void RefreshParenTable()
        {
            if (this.Parent is Car)
            {
                var parent = (Car)Parent;
                parent.RefreshTable();
            }
        }
    }
}
