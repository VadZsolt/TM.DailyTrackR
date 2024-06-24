﻿namespace TM.DailyTrackR.View
{
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
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
        private int no = 0;
        public MainWindow(string username)
        {
            InitializeComponent();
            this.userName = username;
            LoadDailyWorkData(userName, formattedDate);
            LoadDataByDate(formattedDate);
            DateLabel1.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
            DateLabel2.Content = "Actual date: " + formattedDate.ToString("yyyy-MM-dd");
        }

        private void LoadDataByDate(DateTime date)
        {
            string procedureName = "tm.GetActivitiesByDate";
            no = 0;
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
            List<DailyWorkItem> dailyWorkItems = new List<DailyWorkItem>();
            no = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@UserName", username);
                        command.Parameters.AddWithValue("@Date", date);

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
            CreateWindow createWindow = new CreateWindow(userName, no);
            createWindow.ItemInserted += CreateWindow_ItemInserted; // Subscribe to the event
            createWindow.ShowDialog();
        }
        private void CreateWindow_ItemInserted(object sender, EventArgs e)
        {
            LoadDailyWorkData(userName, formattedDate); // Refresh the data grid
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
        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            // Get selected date range from DateRangeCalendar
            DateTime? startDate = DateRangeCalendar.SelectedDates.FirstOrDefault();
            DateTime? endDate = DateRangeCalendar.SelectedDates.LastOrDefault();

            if (startDate.HasValue && endDate.HasValue)
            {
                // Call method to fetch and export data for the selected date range
                List<OverviewItem> filteredData = FetchDataForExport(startDate.Value, endDate.Value);

                // Format the data for export
                StringBuilder exportText = new StringBuilder();

                // Center the first line
                string header = $"Team Activity in the period {startDate.Value.ToString("dd.MM.yyyy")} – {endDate.Value.ToString("dd.MM.yyyy")}";
                int consoleWidth = 80; // Assuming a console width of 80 characters
                int spaces = (consoleWidth - header.Length) / 2;
                exportText.AppendLine(header.PadLeft(spaces + header.Length));

                // Group data by ProjectType and create the export text
                var groupedData = filteredData.GroupBy(item => item.ProjectType);
                foreach (var group in groupedData)
                {
                    exportText.AppendLine($"{group.Key}");
                    exportText.AppendLine(new string('=', group.Key.Length));
                    foreach (var item in group)
                    {
                        exportText.AppendLine($"- {item.Description} – {item.Status}");
                    }
                    exportText.AppendLine(); // Adding a newline after each group
                }

                string fileName = $"TeamWeekActivity_{startDate.Value.ToString("dd-MM-yyyy")}_{endDate.Value.ToString("dd-MM-yyyy")}.txt";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), fileName);

                // Write to file
                File.WriteAllText(filePath, exportText.ToString());

                MessageBox.Show($"Data exported successfully to {filePath}", "Export Complete", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a date range using the calendar.", "Date Range Required", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private List<OverviewItem> FetchDataForExport(DateTime startDate, DateTime endDate)
        {
            List<OverviewItem> result = new List<OverviewItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.ExportBetweenDates", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@StartDate", startDate);
                        command.Parameters.AddWithValue("@EndDate", endDate);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                OverviewItem item = new OverviewItem
                                {
                                    NO = 0,
                                    ProjectType = (string)reader.GetString(reader.GetOrdinal("ProjectType")),
                                    Description = reader.GetString(reader.GetOrdinal("Description")),
                                    Status = (StatusEnum)reader.GetInt32(reader.GetOrdinal("Status")),
                                    User = reader.GetString(reader.GetOrdinal("User"))
                                };
                                result.Add(item);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return result;
        }
    }
}
