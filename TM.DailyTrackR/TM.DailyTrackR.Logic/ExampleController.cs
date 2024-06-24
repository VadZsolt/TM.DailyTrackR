namespace TM.DailyTrackR.Logic
{
    using System.Data;
    using System.Data.SqlClient;

  public sealed class ExampleController
  {
    string connectionString = @"Server=.\TM_DAILY_TRACKR;Database=TRACKR_DATA;Integrated Security=true;";

    public int GetDataExample()
    {
            //csinalni egy insert projectet, procedurat s azt is meghivni
            //command.Parameters.AddWithValue("@param1",value1);
        string query = "SELECT @@VERSION";
        string procedureName = "tm.GetAllProjectTypes";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //List<object> projectIds = new List<object>();
                    Dictionary<int,string> result = new Dictionary<int,string>();
                    while (reader.Read())
                    {
                        result.Add((int)reader["project_type_id"], (string)reader["project_type_description"]);
                        //projectIds.Add(reader["project_type_id"]);
                    }
                }
                //string version = (string)command.ExecuteScalar();
                //System.Diagnostics.Debug.WriteLine("SQL Server Version: " + version);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
      return 0;
    }
    public int InsertData(string projectName)
        {
            string procedureName = "tm.InsertNewProject";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProjectName", projectName);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                    return -1;
                }
            }
        }
        public int UpdateData(int id, string desc)
        {
            string procedureName = "TM.UpdateProjectType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProjectId", id);
                        command.Parameters.AddWithValue("@ProjectDesc", desc);

                        connection.Open();
                        //https://www.aspsnippets.com/Articles/4174/Update-data-into-Database-using-Stored-Procedure-in-Windows-Forms/
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);

                }
            }

            return 0;
        }


        public int DeleteData(int id)
        {
            string procedureName = "TM.DeleteProjectType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ProjectId", id);
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        return rowsAffected;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }

            return 0;
        }
        
    }
}
