using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
