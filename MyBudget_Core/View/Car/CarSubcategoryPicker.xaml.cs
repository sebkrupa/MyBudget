using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace MyBudget_Core.View.Car
{
    /// <summary>
    /// Interaction logic for CarSubcategoryPicker.xaml
    /// </summary>
    public partial class CarSubcategoryPicker : UserControl
    {
        public CarSubcategoryPicker()
        {
            InitializeComponent();
            SetDefaultSubCategory();
            categoriesPicker.cbxSubCategory.SelectionChanged += (s, e) => SetNewSubCategoryToFuelExpenditures();

        }

        private void SetDefaultSubCategory()
        {
            if (DBSettings.Default.FuelSubCategory != 0)
            {
                var selectedSubCategory = new MyBudgetAPI.Read.SubCategory().GetSingle(DBSettings.Default.FuelSubCategory);
                categoriesPicker.cbxCategory.SelectedItem = ((IEnumerable<MyBudgetAPI.Model.Category>)categoriesPicker.cbxCategory.ItemsSource).
                                                                                            Where(x => x.id == selectedSubCategory.categoryId).FirstOrDefault();
                categoriesPicker.cbxSubCategory.SelectedItem = ((IEnumerable<MyBudgetAPI.Model.SubCategory>)categoriesPicker.cbxSubCategory.ItemsSource).
                                                                                                        Where(x => x.id == selectedSubCategory.id).FirstOrDefault();
            }
        }

        private void SetNewSubCategoryToFuelExpenditures()
        {
            if (categoriesPicker.cbxSubCategory.SelectedItem != null)
            {
                DBSettings.Default.FuelSubCategory = ((MyBudgetAPI.Model.SubCategory)categoriesPicker.cbxSubCategory.SelectedItem).id;
                DBSettings.Default.Save();
            }
        }
    }
}
