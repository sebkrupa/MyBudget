using Microsoft.Win32;
using System.Windows;

namespace MyBudget_Core
{
    internal static class DB
    {
        /// <summary>
        /// zweryfikuj i połącz się z bazą danych
        /// </summary>
        internal static void ValidateDB()
        {
            //jeżeli dotąd nie wybrano zadnej bazy
            if (string.IsNullOrWhiteSpace(DBSettings.Default.DBPath))
            {
                var msg = MessageBox.Show("Nie wybrano żadnej bazy danych. Czy chcesz wybrać nową bazę?",
                     "Brak bazy danych", MessageBoxButton.YesNo, MessageBoxImage.Information);
                if (msg == MessageBoxResult.No) Application.Current.Shutdown();
                GetNewDBPath();
            }
            //jeżeli wybrano, sprawdź czy na pewno istnieje
            if (System.IO.File.Exists(DBSettings.Default.DBPath))
                MyBudgetAPI.DB.DBPath = DBSettings.Default.DBPath;
            else
            {
                var msg = MessageBox.Show($"Nie można zlokalizować obecnej bazy danych:\n{DBSettings.Default.DBPath}\n" +
                        $"Czy chcesz wskazać nową lokalizację?", "Błąd połączenia z bazą", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (msg == MessageBoxResult.No) Application.Current.Shutdown();
                GetNewDBPath();
            }
        }

        internal static void GetNewDBPath()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "Bazy danych (*.db)|*.db";
            dialog.CheckFileExists = true;
            dialog.ShowDialog();

            SetDB(dialog.FileName);
            ValidateDB();
        }

        private static void SetDB(string path)
        {
            MyBudgetAPI.DB.DBPath = path;
            DBSettings.Default.DBPath = path;
            DBSettings.Default.Save();
        }

        internal static void CreateNewDB()
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.DefaultExt = "db";
            dialog.Filter = "Bazy danych(*.db)| *.db";
            dialog.AddExtension = true;
            dialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(dialog.FileName))
            {
                MyBudgetAPI.DB.CreateNewDB(dialog.FileName);
                MessageBox.Show($"Utworzono nową bazę danych w lokalizacji:\n{dialog.FileName}");
            }

        }


    }
}
