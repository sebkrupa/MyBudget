using System;
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
            Refresh();
            SelectionChangedEvent = new SelectionChangedEventHandler(SelectCategory);
            cbxCategory.SelectionChanged += SelectionChangedEvent;
            Model.Windows.RefreshView += Refresh;
        }

        private void Refresh()
        {
            cbxSubCategory.ItemsSource = null;
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
        }

        public void ChangeCategorySelectionChanged(Action<object, SelectionChangedEventArgs> action)
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
