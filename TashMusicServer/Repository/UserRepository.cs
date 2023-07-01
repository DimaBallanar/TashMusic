using System;
using MySqlConnector;

public class UserRepository
{
	
		 private readonly string SQL_selectItems = "select*from Users;";     

        public List<string> GetAllUsersFromDB(MySqlConnection connection)
        {
            if (connection == null) throw new Exception("connection error");
            try
            {                
                List<string> scripts = new List<string>();
                MySqlCommand command = new MySqlCommand(SQL_selectItems, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    scripts.Add(reader.GetString(0));
                }
                return scripts;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
	
}
