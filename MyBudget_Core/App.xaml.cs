using Microsoft.Win32;
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
            MessageBox.Show("Wystąpił nieoczekiwany błąd. Jeżeli się powtarza, być może zmiana lokalizacji bazy danych coś pomoże?");
            DB.GetNewDBPath();
        }
    }
}
