using System;
using System.Windows;
using System.Windows.Controls;

namespace MyBudget_Core.View
{
    /// <summary>
    /// Interaction logic for Subscriptions.xaml
    /// </summary>
    public partial class Subscriptions : UserControl
    {
        public Subscriptions()
        {
            InitializeComponent();
            PrepareControl();
            Model.Windows.RefreshView += PrepareControl;
        }

        private void PrepareControl()
        {
            datePicker.SelectedDate = DateTime.Now;
            listSubs.ItemsSource = ViewModel.Subscriptions.GetSubscriptionsList();
            txtSumYearly.Text += ViewModel.Subscriptions.GetSumOfYearlySubs();
        }

        private void Button_Click(object sender, RoutedEventArgs e) =>
            ViewModel.Subscriptions.AddNewSubscription(
                txtName.Text,
                datePicker.SelectedDate.Value,
                txtComment.Text,
                Decimal.Parse(txtValue.Text),
                Convert.ToInt32(((ComboBoxItem)cbxTimeFrame.SelectedItem).Tag));
    }
}
