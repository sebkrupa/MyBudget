using System;
using System.Windows;

namespace MyBudget_Core
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e) => DB.ValidateDB();
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is ArgumentNullException)
            {
                MessageBox.Show("Prawdopodobnie wystąpił błąd z bazą danych. Zalecana jest zmiana lokalizacji bazy.");
                DB.GetNewDBPath();

            }

        }


    }
}
