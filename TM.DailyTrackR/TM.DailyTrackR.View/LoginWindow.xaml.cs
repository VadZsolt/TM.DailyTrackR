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

namespace TM.DailyTrackR.View
{
    public partial class LoginWindow : Window
    {
        private string connectionString= @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";
        public LoginWindow()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //saves user and pass, and validates it
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            MainWindow mainWindow;
            if (ValidateUser(username, password))
            {
                if (Leader(username) == 1)
                {
                     mainWindow = new MainWindow(username,1);
                }
                else
                {
                    mainWindow = new MainWindow(username, 0);
                }
                
                mainWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private bool ValidateUser(string username, string password)
        {
            //validation, user and password are correct
            bool isValid = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.ValidateUser", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        SqlParameter returnValue = new SqlParameter();
                        returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
                        command.Parameters.Add(returnValue);

                        command.ExecuteNonQuery();

                        int result = (int)returnValue.Value;
                        isValid = (result == 1);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return isValid;
        }
        private int Leader(string username)
        {
            //checks if logged in user is leader or not
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("tm.IsLeader", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@Username", username);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                result = reader.GetInt32(reader.GetOrdinal("isLeader"));
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
