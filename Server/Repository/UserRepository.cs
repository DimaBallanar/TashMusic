using MySql.Data.MySqlClient;
using MusicServer.Models.Repository;
using System.Reflection.PortableExecutable;
using System.Text;
//using static Google.Protobuf.Collections.MapField<TKey, TValue>;

namespace MusicServer.Repository
{
    public class UserRepository : BaseRepository
    {
        private readonly string SQL_SELECT_GET_ALL = "Select id,name,surname,email,password from users";
        private readonly string SQL_SELECT_GET_BY_EMAIL = "Select id,name,surname,email,password from users where email=@email;";
        private readonly string SQL_PUT_ITEM = "insert into users(name,surname,email,password) values (@name, @surname, @email, @password)";
        private readonly string SQL_UPDATE_USER = "UPDATE users Set name=@name, surname=@surname, email=@email,password=@password where Id=@id";
        private readonly string SQL_DELETE_USER = "delete from users where Id=@id;";

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
        public List<User> GetAll(int id)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                List<User> users = new List<User>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
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
                }
                return users;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public User GetByEmail(string email)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_BY_EMAIL, m_Connection);
                cmd.Parameters.AddWithValue("@email", email.ToLower());
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    User user = new User()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Surname = reader.GetString(2),
                        Email = reader.GetString(3).ToLower(),
                        Password = reader.GetString(4)
                    };

                    return user;
                }
                return null;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public void Test(MySqlConnection conn, string script, params object[] item)
        {                                           //команда
            // ? -> @pr{i}
            //script.IndexOf()


            int startIndex = 0;
            int i = 0;

            while (startIndex < script.Length)
            {
                startIndex = script.IndexOf("?", startIndex);
                if (startIndex == -1) { break; }
                script = script.Remove(startIndex, 1);
                script = script.Insert(startIndex, $"pr{i++}");
            }

            MySqlCommand command = new MySqlCommand(script, conn);

            for (i = 0; i < item.Length; i++)
            {
                command.Parameters.AddWithValue($"pr{i}", item[i]);
            }
            command.ExecuteNonQuery();

        }

        public int Put(User user)
        {
            try
            {
                m_Connection.Open();
                //MySqlCommand cmd = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
                Test(m_Connection, SQL_PUT_ITEM, user.Name, user.Surname, user.Email, user.Password);
                //MySqlDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    if (reader.GetString(3) != user.Email)
                //    {
                //        m_Connection.Close();
                //        User user1 = new User();
                //        m_Connection.Open();
                //        MySqlCommand command = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
                //        //MySqlCommand command = m_Connection.CreateCommand();
                //        //command.CommandText = SQL_PUT_ITEM;
                //        command.Parameters.AddWithValue("@name", user.Name);
                //        command.Parameters.AddWithValue("@surname", user.Surname);
                //        command.Parameters.AddWithValue("@email", user.Email);
                //        command.Parameters.AddWithValue("@password", user.Password);

                //        //cmd.ExecuteNonQuery();
                //        command.ExecuteNonQuery();
                //        return (int)command.LastInsertedId;
                //    }

                //}
                return -1;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        //public int Put(User user)
        //{
        //    try
        //    {
        //        m_Connection.Open();
        //        MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);               
        //        MySqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            if (reader.GetString(3) != user.Email)
        //            {
        //                m_Connection.Close();
        //                User user1 = new User();
        //                m_Connection.Open();
        //                MySqlCommand command=new MySqlCommand(SQL_PUT_ITEM, m_Connection);
        //                //MySqlCommand command = m_Connection.CreateCommand();
        //                //command.CommandText = SQL_PUT_ITEM;
        //                command.Parameters.AddWithValue("@name", user.Name);
        //                command.Parameters.AddWithValue("@surname", user.Surname);
        //                command.Parameters.AddWithValue("@email", user.Email);
        //                command.Parameters.AddWithValue("@password", user.Password);

        //                //cmd.ExecuteNonQuery();
        //                command.ExecuteNonQuery();
        //                return (int)command.LastInsertedId;
        //            }

        //        }
        //        return -1;
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }
        //}

        public List<User> Update(User user)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_USER, m_Connection);
                cmd.Parameters.AddWithValue("@email", user.Email.ToLower());

                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@surname", user.Surname);
                cmd.Parameters.AddWithValue("@email", user.Email.ToLower());
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.ExecuteNonQuery();
                m_Connection.Close();
                List<User> users = GetAll();
                return users;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public List<User> Delete(int code)
        {
            try
            {
                m_Connection.Open();

                MySqlCommand command = new MySqlCommand(SQL_DELETE_USER, m_Connection);
                command.Parameters.AddWithValue("@id", code);
                command.ExecuteNonQuery();
                m_Connection.Close();
                List<User> users = GetAll();
                return users;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
