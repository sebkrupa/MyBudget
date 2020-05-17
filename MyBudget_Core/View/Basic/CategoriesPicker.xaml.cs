using MyBudgetAPI.Create;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;

namespace MyBudget_Core.View.Basic
{
    /// <summary>
    /// Interaction logic for CategoriesPicker.xaml
    /// </summary>
    public partial class CategoriesPicker : UserControl
    {
        public SelectionChangedEventHandler SelectionChangedEvent;
        public CategoriesPicker()
        {
            InitializeComponent();
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
            SelectionChangedEvent = new SelectionChangedEventHandler(SelectCategory);
            cbxCategory.SelectionChanged += SelectionChangedEvent;
        }

        public void ChangeCategorySelectionChanged(Action<object,SelectionChangedEventArgs> action)
        {
            cbxCategory.SelectionChanged -= SelectionChangedEvent;
            cbxCategory.SelectionChanged += new SelectionChangedEventHandler(action);
        }

        public void SelectCategory(object sender, SelectionChangedEventArgs e)
        {
            if (cbxCategory.SelectedItem != null)
            {
                cbxSubCategory.ItemsSource = null;
                var list = new MyBudgetAPI.Read.SubCategory().GetAll().Where(x =>
                x.categoryId == ((MyBudgetAPI.Model.Category)cbxCategory.SelectedItem).id).ToList();
                cbxSubCategory.ItemsSource = list;
            }
        }
    }
}
