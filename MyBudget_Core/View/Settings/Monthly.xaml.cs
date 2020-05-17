using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MyBudget_Core.View.Settings
{
    /// <summary>
    /// Interaction logic for Monthly.xaml
    /// </summary>
    public partial class Monthly : UserControl
    {
        public Monthly()
        {
            InitializeComponent();
            PrepareControl();
            categoriesPicker.cbxCategory.SelectionChanged -= categoriesPicker.SelectionChangedEvent;
            categoriesPicker.ChangeCategorySelectionChanged(CategoryChangedEvent);
        }

        private void CategoryChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            if (categoriesPicker.cbxCategory.SelectedItem != null)
            {
                categoriesPicker.cbxSubCategory.ItemsSource = null;
                var alreadyAdded = new MyBudgetAPI.Read.Monthly().GetAll();
                var list = new MyBudgetAPI.Read.SubCategory().GetAll().Where(x =>
                x.categoryId == ((MyBudgetAPI.Model.Category)categoriesPicker.cbxCategory.SelectedItem).id).ToList();
                foreach (var c in alreadyAdded)
                {
                    var toRemove = list.Where(x => x.id == c.subCategoryId).FirstOrDefault();
                    list.Remove(toRemove);
                }
                categoriesPicker.cbxSubCategory.ItemsSource = list;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e) => AddNewCategory();

        private void PrepareControl()
        {
            listCategories.ItemsSource = new MyBudgetAPI.Read.Monthly().GetAll().OrderBy(x => x.name);
            CategoryChangedEvent(null, null);
        }


        private void AddNewCategory()
        {
            if (categoriesPicker.cbxSubCategory.SelectedItem != null)
            {
                new MyBudgetAPI.Create.Monthly().Add(new MyBudgetAPI.Model.Monthly
                {
                    subCategoryId = ((MyBudgetAPI.Model.SubCategory)categoriesPicker.cbxSubCategory.SelectedItem).id,
                    toSplit = cbxToSplit.SelectedIndex
                });
                PrepareControl();
            }
        }

        private void MenuItem_DeleteCategory(object sender, RoutedEventArgs e)
        {
            if (listCategories.SelectedItem != null)
            {
                var categoryToRemove = (MyBudgetAPI.Model.Monthly)listCategories.SelectedItem;
                new MyBudgetAPI.Delete.Monthly().RemoveItem(categoryToRemove);
                PrepareControl();
            }
        }
    }
}
