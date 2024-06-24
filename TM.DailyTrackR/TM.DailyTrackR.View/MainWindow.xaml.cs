namespace TM.DailyTrackR.View
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Windows;
    using System.Windows.Controls;
    using TM.DailyTrackR.DataType;
    using TM.DailyTrackR.DataType.Enums;
    using static System.Runtime.InteropServices.JavaScript.JSType;

    public partial class MainWindow : Window
  {
        private string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";
        private DateTime formattedDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        private string userName = string.Empty;
        public MainWindow(string username)
        {
            InitializeComponent();
            this.userName = username;
            LoadDailyWorkData(userName,formattedDate);
            LoadDataByDate(formattedDate);
            DateLabel1.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
            DateLabel2.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
        }

        private void LoadDataByDate(DateTime date)
        {
            string procedureName = "tm.GetActivitiesByDate";
            int no = 0;
            List<OverviewItem> overviewItems = new List<OverviewItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Date", date);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            no++;
                            OverviewItem item = new OverviewItem
                            {
                                NO = no,
                                ProjectType = (string)reader["Project type"],
                                Description = (string)reader["Description"],
                                Status = (StatusEnum)reader["Status"],
                                User = (string)reader["User"]
                            };
                            overviewItems.Add(item);
                        }
                        OverviewDataGrid.ItemsSource = overviewItems;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }

        private void LoadDailyWorkData(string username, DateTime date)
        {
            
            string procedureName = "tm.GetActivitiesUserDate";
            int no = 0;
            List<DailyWorkItem> dailyWorkItems = new List<DailyWorkItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Date",date);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            no++;
                            DailyWorkItem item = new DailyWorkItem
                            {
                                NO = no,
                                ProjectType = (string)reader["Project type"],
                                TaskType = (TaskTypeEnum)reader["Task type"],
                                Description = (string)reader["Description"],
                                Status = (StatusEnum)reader["Status"],
                                id = (int)reader["id"]
                            };
                            dailyWorkItems.Add(item);
                        }
                        DailyWorkDataGrid.ItemsSource = dailyWorkItems;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Calendar.SelectedDate.HasValue)
            {
                formattedDate = new DateTime(Calendar.SelectedDate.Value.Year, Calendar.SelectedDate.Value.Month, Calendar.SelectedDate.Value.Day);
            }
            LoadDataByDate(formattedDate);
            LoadDailyWorkData(userName, formattedDate);
            DateLabel1.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
            DateLabel2.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
        }
        private void DailyWorkDataGrid_MouseRightButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            if (dataGrid != null)
            {
                dataGrid.ContextMenu.IsOpen = true;
            }
        }
        private void CreateMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.ShowDialog();
        }
        private void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (DailyWorkDataGrid.SelectedItem != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected item?", "Confirmation", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    DailyWorkItem selectedItem = DailyWorkDataGrid.SelectedItem as DailyWorkItem;
                    if (selectedItem != null)
                    {
                        DeleteDailyWorkItemFromDatabase(selectedItem);
                        ((List<DailyWorkItem>)DailyWorkDataGrid.ItemsSource).Remove(selectedItem);
                        DailyWorkDataGrid.Items.Refresh();
                    }
                }
            }
            else
            {
                MessageBox.Show("No item selected.");
            }
        }
        private void DeleteDailyWorkItemFromDatabase(DailyWorkItem item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.DeleteActivity", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Id", item.id);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
