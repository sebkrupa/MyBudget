using System;
using System.Collections.Generic;
using System.Linq;
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
            cbxCategory.SelectionChanged += (s, e) =>
            {
                if(cbxCategory.SelectedItem != null)
                {
                    cbxSubCategory.ItemsSource = null;
                    var alreadyAdded = new MyBudgetAPI.Read.Monthly().GetAll();
                    var list = new MyBudgetAPI.Read.SubCategory().GetAll().Where(x =>
                    x.categoryId == ((MyBudgetAPI.Model.Category)cbxCategory.SelectedItem).id).ToList();
                    foreach (var c in alreadyAdded)
                    {
                        var toRemove = list.Where(x => x.id == c.id).FirstOrDefault();
                        list.Remove(toRemove);
                    }
                    cbxSubCategory.ItemsSource = list;
                }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e) => AddNewCategory();

        private void PrepareControl()
        {
            listCategories.ItemsSource = new MyBudgetAPI.Read.Monthly().GetAll().OrderBy(x => x.name);
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
            cbxSubCategory.ItemsSource = null;
        }

        private void AddNewCategory()
        {
            if (cbxSubCategory.SelectedItem!=null)
            {
                new MyBudgetAPI.Create.Monthly().Add(new MyBudgetAPI.Model.Monthly 
                { 
                    subCategoryId = ((MyBudgetAPI.Model.SubCategory)cbxSubCategory.SelectedItem).id,
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
