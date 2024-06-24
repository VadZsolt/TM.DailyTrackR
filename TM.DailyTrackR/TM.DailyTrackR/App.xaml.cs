namespace TM.DailyTrackR
{
  using System.Windows;
  using TM.DailyTrackR.View;
  using TM.DailyTrackR.ViewModel;

    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
        }
    }
}
