using Microsoft.Xaml.Behaviors.Layout;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TM.DailyTrackR.DataType;
using TM.DailyTrackR.DataType.Enums;

namespace TM.DailyTrackR.View
{
    public partial class CreateWindow : Window
    {
        public DailyWorkItem NewItem { get; private set; }
        public event EventHandler ItemInserted;
        private string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";
        private string userName;
        private int no = 0;

        public CreateWindow(string username, int no)
        {
            InitializeComponent();
            this.userName = username;
            this.no = no;
            LoadEnumValues();
            LoadProjectTypes();

        }

        private void LoadEnumValues()
        {
            TaskTypeComboBox.ItemsSource = Enum.GetValues(typeof(TaskTypeEnum));
            StatusComboBox.ItemsSource = Enum.GetValues(typeof(StatusEnum));
        }

        private void LoadProjectTypes()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.GetAllProjectTypes", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> projectTypes = new List<string>();
                            while (reader.Read())
                            {
                                projectTypes.Add(reader["project_type_description"].ToString());
                            }
                            ProjectTypeComboBox.ItemsSource = projectTypes;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            NewItem = new DailyWorkItem
            {
                NO = this.no,
                ProjectType = ProjectTypeComboBox.SelectedItem.ToString(),
                TaskType = (TaskTypeEnum)TaskTypeComboBox.SelectedItem,
                Description = DescriptionTextBox.Text,
                Status = (StatusEnum)StatusComboBox.SelectedItem,
                //Date = DatePicker.SelectedDate.Value
            };

            InsertNewItemIntoDatabase(NewItem,DatePicker.SelectedDate.Value);

            DialogResult = true;
            ItemInserted?.Invoke(this, EventArgs.Empty);
            Close();
        }

        private void InsertNewItemIntoDatabase(DailyWorkItem item, DateTime date)
        {
            int ProjectId=-1;
            object result;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.ProjectStringToInt", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProjectString",item.ProjectType.ToString());
                        result = command.ExecuteScalar();
                        if (result != null)
                        {
                            ProjectId = Convert.ToInt32(result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.InsertActivity", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProjectId", ProjectId);
                        command.Parameters.AddWithValue("@ActivityId", (int)item.TaskType);
                        command.Parameters.AddWithValue("@Description", item.Description);
                        command.Parameters.AddWithValue("@StatusId", (int)item.Status);
                        command.Parameters.AddWithValue("@Username", userName);
                        command.Parameters.AddWithValue("@Date", date);
                        //create insertActivity procedure
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
