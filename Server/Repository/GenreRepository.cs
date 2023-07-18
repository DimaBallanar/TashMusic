using MusicServer.Models.Repository;
using MySql.Data.MySqlClient;

namespace MusicServer.Repository
{
    public class GenreRepository:BaseRepository
    {
        private readonly string SQL_SELECT_GET_ALL = "Select id,type from GenreofMusic";
        private readonly string SQL_PUT_ITEM = "insert into Genreofmusic(Type) values (@type)";

        public GenreRepository(MySqlConnection connection) : base(connection)
        {
        }
        public List<Genre> GetAll()
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);               
                List<Genre> genres = new List<Genre>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    genres.Add(new Genre()
                    {
                        Id = reader.GetInt32(0),
                        Type = reader.GetString(1)                  
                                            });
                }
                return genres;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public int Put(Genre genre)
        {
            try
            {
                m_Connection.Open();
                        MySqlCommand command = new MySqlCommand(SQL_PUT_ITEM, m_Connection);
                        command.Parameters.AddWithValue("@type", genre.Type);                      
                        command.ExecuteNonQuery();
                        return (int)command.LastInsertedId;                  
               
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
    }
}
