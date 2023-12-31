﻿using MySql.Data.MySqlClient;
using MusicServer.Models.Repository;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml.Linq;
//using static Google.Protobuf.Collections.MapField<TKey, TValue>;

namespace MusicServer.Repository
{
    public class UserRepository : BaseRepository
    {
        private readonly string SQL_SELECT_GET_ALL = "Select id, name, email, number from users";
        private readonly string SQL_SELECT_GET_BY_EMAIL = "Select id, name, email, number, password from users where email=@email;";
        private readonly string SQL_PUT_ITEM = "insert into users(name,email,number,password) values (@name, @email, @number, @password)";
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
                        Email = reader.GetString(2).ToLower(),
                        PhoneNumber = reader.GetString(3).ToLower(),
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
       
        public User GetByEmail(string email, string password)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_BY_EMAIL, m_Connection);
                cmd.Parameters.AddWithValue("@email", email.ToLower());
                MySqlDataReader reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    return null;

                }
                return new User
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Email = reader.GetString(2).ToLower(),
                    PhoneNumber = reader.GetString(3).ToLower(),
                    Password = reader.GetString(4)
                }; 

            }
            catch (MySqlException e)
            {
                throw e;
            }
            finally
            {
                m_Connection.Close();
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

        //public int Put(User user)
        //{
        //    try
        //    {
        //        m_Connection.Open();
        //        //MySqlCommand cmd = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
        //        Test(m_Connection, SQL_PUT_ITEM, user.Name, user.Email,user.PhoneNumber, user.Password);
        //        //MySqlDataReader reader = cmd.ExecuteReader();
        //        //while (reader.Read())
        //        //{
        //        //    if (reader.GetString(3) != user.Email)
        //        //    {
        //        //        //m_Connection.Close();
        //        //        User user1 = new User();
        //        //        //m_Connection.Open();
        //        //        MySqlCommand command = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
        //        //        //MySqlCommand command = m_Connection.CreateCommand();
        //        //        //command.CommandText = SQL_PUT_ITEM;
        //        //        cmd.Parameters.AddWithValue("@name", user.Name);
        //        //        cmd.Parameters.AddWithValue("@email", user.Email.ToLower());
        //        //        cmd.Parameters.AddWithValue("@number", user.PhoneNumber.ToLower());
        //        //        cmd.Parameters.AddWithValue("@password", user.Password);

        //        //        //cmd.ExecuteNonQuery();
        //        //        command.ExecuteNonQuery();
        //        //        return (int)command.LastInsertedId;
        //        //    }

        //        //}
        //        return -1;
        //    }
        //    catch (MySqlException e)
        //    {
        //        throw e;
        //    }
        //}

        public int Create(User user)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
                command.Parameters.AddWithValue("@name", user.Name);
                command.Parameters.AddWithValue("@email", user.Email.ToLower());
                command.Parameters.AddWithValue("@number", user.PhoneNumber.ToLower());
                command.Parameters.AddWithValue("@password", user.Password);
                command.ExecuteNonQuery();
                m_Connection.Close();
                return (int)command.LastInsertedId;

            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public List<User> Update(User user)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_UPDATE_USER, m_Connection);

                cmd.Parameters.AddWithValue("@name", user.Name);               
                cmd.Parameters.AddWithValue("@number", user.PhoneNumber.ToLower());
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
