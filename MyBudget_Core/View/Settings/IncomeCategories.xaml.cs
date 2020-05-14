using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyBudget_Core.View.Settings
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class IncomeCategories : UserControl
    {
        public IncomeCategories()
        {
            InitializeComponent();
            PrepareControl();
        }

        private void Button_Click(object sender, RoutedEventArgs e) => AddNewCategory();

        private void PrepareControl() => listCategories.ItemsSource = new MyBudgetAPI.Read.IncomeCategory().GetAll().OrderBy(x => x.name);

        private void AddNewCategory()
        {
            if (!string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                new MyBudgetAPI.Create.IncomeCategory().Add(new MyBudgetAPI.Model.IncomeCategory { name = txtCategoryName.Text });
                PrepareControl();
                txtCategoryName.Text = string.Empty;
            }
        }

        private void MenuItem_DeleteCategory(object sender, RoutedEventArgs e)
        {
            if (listCategories.SelectedItem != null)
            {
                var categoryToRemove = (MyBudgetAPI.Model.IncomeCategory)listCategories.SelectedItem;
                new MyBudgetAPI.Delete.IncomeCategory().RemoveItem(categoryToRemove);
                PrepareControl();
            }
        }
    }
}
