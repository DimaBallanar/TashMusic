using MySqlConnector;

namespace Server.Repository

{
	public class UserRepository:BaseRepository
	{
		private readonly string SQL_selectItems = "select*from Users;";

        public UserRepository(MySqlConnection connection) : base(connection)
        {
        }
        public List<User> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                List<User> users = new List<User>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3).ToLower(),
                        Password = reader.GetString(4)
                    });
                }
                return users;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}
