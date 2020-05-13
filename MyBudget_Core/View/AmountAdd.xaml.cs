using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyBudget_Core.View
{
    /// <summary>
    /// Interaction logic for AmountAdd.xaml
    /// </summary>
    public partial class AmountAdd : UserControl
    {
        private bool expenditure;
        private bool Expenditure
        {
            get { return expenditure; }
            set
            {
                if (value != expenditure)
                {
                    expenditure = value;
                    if (expenditure) ShowExpenditure();
                    else ShowIncome();
                }
            }
        }
        public AmountAdd()
        {
            InitializeComponent();
            cbxCategory.SelectionChanged += (s, e) => UpdateSubCategoryOnCategoryChange();
            cbxInputType.SelectionChanged += (s, e) => { Expenditure = !Convert.ToBoolean(((ComboBox)s).SelectedIndex); };
            txtValue.PreviewKeyDown += (s, e) => { if (e.Key == Key.Enter) AddNew(); };
            Expenditure = true;
        }

        private Regex numericOnly = new Regex("[^0-9.-]+");

        private void txtValue_PreviewTextInput(object sender, TextCompositionEventArgs e) => e.Handled = numericOnly.IsMatch(e.Text);

        private void ShowExpenditure()
        {
            cbxSubCategory.Visibility = Visibility.Visible;
            cbxCategory.ItemsSource = null;
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
            cbxCategory.SelectedIndex = -1;
        }

        private void ShowIncome()
        {
            cbxSubCategory.Visibility = Visibility.Collapsed;
            cbxCategory.ItemsSource = null;
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.IncomeCategory().GetAll().OrderBy(x => x.name);
            cbxCategory.SelectedIndex = -1;
        }

        private void UpdateSubCategoryOnCategoryChange()
        {
            if (Expenditure)
            {
                if (cbxCategory.SelectedIndex != -1)
                {
                    cbxSubCategory.ItemsSource = null;
                    cbxSubCategory.ItemsSource = new MyBudgetAPI.Read.SubCategory().GetAll()
                        .Where(x => x.categoryId == ((MyBudgetAPI.Model.Category)cbxCategory.SelectedItem).id)
                        .OrderBy(x => x.name);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => AddNew();

        private void AddNew()
        {
            if (!string.IsNullOrWhiteSpace(txtValue.Text))
                if (Expenditure)
                    AddExpense();
                else
                    AddIncome();
        }

        private void AddExpense()
        {
            var newItem = new MyBudgetAPI.Model.Expenses(Convert.ToDouble(txtValue.Text),
                ((MyBudgetAPI.Model.SubCategory)cbxSubCategory.SelectedItem).id,
                txtComment.Text, DateTime.Now.ToString());
            new MyBudgetAPI.Create.Expenses().Add(newItem);
            ClearTxtControls();
        }
        private void AddIncome()
        {
            var newItem = new MyBudgetAPI.Model.Income(Convert.ToDouble(txtValue.Text),
                DateTime.Now.ToString(), txtComment.Text, ((MyBudgetAPI.Model.IncomeCategory)cbxCategory.SelectedItem).id);
            new MyBudgetAPI.Create.Income().Add(newItem);
            ClearTxtControls();
        }

        private void ClearTxtControls() => txtComment.Text = txtValue.Text = string.Empty;
    }
}
