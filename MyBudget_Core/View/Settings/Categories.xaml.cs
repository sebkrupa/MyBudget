using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyBudget_Core.View.Settings
{
    /// <summary>
    /// Interaction logic for Categories.xaml
    /// </summary>
    public partial class Categories : UserControl
    {
        public Categories()
        {
            InitializeComponent();
            PrepareControl();
            listCategories.SelectionChanged += (s, e) =>
            {
                if (listCategories.SelectedItem != null)
                {
                    listSubCategories.ItemsSource = null;
                    listSubCategories.ItemsSource = new MyBudgetAPI.Read.SubCategory().
                    GetAll().
                    Where(x => x.categoryId == ((MyBudgetAPI.Model.Category)listCategories.SelectedItem).id).
                    OrderBy(x => x.name);
                }
            };
            Model.Windows.RefreshView += PrepareControl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag.ToString() == "cat")
                AddNewCategory();
            else
                AddNewSubCategory();
        }

        private void PrepareControl()
        {
            listCategories.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
            listSubCategories.ItemsSource = null;
        }

        private void AddNewCategory()
        {
            if (!string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                new MyBudgetAPI.Create.Category().Add(new MyBudgetAPI.Model.Category { name = txtCategoryName.Text });
                PrepareControl();
                txtCategoryName.Text = string.Empty;
            }
        }

        private void AddNewSubCategory()
        {
            if (listCategories.SelectedItem != null && !string.IsNullOrWhiteSpace(txtSubCategoryName.Text))
            {
                new MyBudgetAPI.Create.SubCategory().Add(new MyBudgetAPI.Model.SubCategory
                {
                    categoryId = ((MyBudgetAPI.Model.Category)listCategories.SelectedItem).id,
                    name = txtSubCategoryName.Text
                });
                int selectedCategory = listCategories.SelectedIndex;
                PrepareControl();
                listCategories.SelectedIndex = selectedCategory;
                txtSubCategoryName.Text = string.Empty;
            }
        }

        private void MenuItem_DeleteCategory(object sender, RoutedEventArgs e)
        {
            if (listCategories.SelectedItem != null)
            {
                var categoryToRemove = (MyBudgetAPI.Model.Category)listCategories.SelectedItem;
                new MyBudgetAPI.Delete.Category().RemoveItem(categoryToRemove);
                PrepareControl();
            }
        }

        private void MenuItem_DeleteSubCategory(object sender, RoutedEventArgs e)
        {
            if (listSubCategories.SelectedItem != null)
            {
                var subCategoryToRemove = (MyBudgetAPI.Model.SubCategory)listSubCategories.SelectedItem;
                new MyBudgetAPI.Delete.SubCategory().RemoveItem(subCategoryToRemove);
                PrepareControl();
            }
        }
    }
}
