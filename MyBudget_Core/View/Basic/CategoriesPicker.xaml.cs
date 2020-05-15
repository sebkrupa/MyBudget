using System.Linq;
using System.Windows.Controls;

namespace MyBudget_Core.View.Basic
{
    /// <summary>
    /// Interaction logic for CategoriesPicker.xaml
    /// </summary>
    public partial class CategoriesPicker : UserControl
    {
        public CategoriesPicker()
        {
            InitializeComponent();
            cbxCategory.ItemsSource = new MyBudgetAPI.Read.Category().GetAll().OrderBy(x => x.name);
            cbxCategory.SelectionChanged += (s, e) => SelectCategory();
        }

        public virtual void SelectCategory()
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
