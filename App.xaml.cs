using System.Configuration;
using System.Data;
using System.Windows;

namespace KeenVPN
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            Infrastructure.SessionStore.CurrentSession = null;
            // Add any other cleanup logic here
        }
    }
}
