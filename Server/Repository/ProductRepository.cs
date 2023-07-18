using MySql.Data.MySqlClient;
using MusicServer.Models.Repository;

namespace MusicServer.Repository
{
    public class ProductRepository : BaseRepository
    {
      
        private readonly string SQL_SELECT_GET_ALL = "Select id,name,description,price,brand_id,category_id from Product";
        private readonly string SQL_PUT_ITEM = "insert into Product(name,filepath,genreid) values (@name, @filepath, @genreid)";       
        private readonly string SQL_DELETE_PRODUCT = "delete from Product where Id=@id;";
        //private readonly string SQL_SELECT_FOR_VIEW_PRODUCTS= @"select c.name as Продукт ,description as описание,price  as цена,b.name as бренд,c.Name as категория from product p
        //                                                        inner join brand b
        //                                                        on b.ID=p.brand_id
        //                                                        inner join category c
        //                                                        on c.ID= p.category_id;";
                                                                
        public ProductRepository(MySqlConnection connection) : base(connection)
        {
        }
        public List<Product> GetAll()
        {
          
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                //MySqlCommand cmd = new MySqlCommand(SQL_SELECT_FOR_VIEW_PRODUCTS, m_Connection);
                List<Product> products = new List<Product>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        FilePath = reader.GetString(2),
                        GenreId = reader.GetInt32(3),
                       

                    });
                }
                return products;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public Product GetById(int id)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                Product product = new Product();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                    {
                        product.Id = reader.GetInt32(0);
                        product.Name = reader.GetString(1);
                        product.FilePath = reader.GetString(2).ToLower();
                        product.GenreId = reader.GetInt32(3);                          
                       
                    }
                }
                return product;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }

        public int Put(Product product)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(1) != product.Name)
                    {
                        m_Connection.Close();
                        Product product1 = new Product();
                        m_Connection.Open();
                        MySqlCommand command = new MySqlCommand(SQL_PUT_ITEM, m_Connection);                       
                        command.Parameters.AddWithValue("@name", product.Name);
                        command.Parameters.AddWithValue("@description", product.FilePath);
                        command.Parameters.AddWithValue("@genreid", product.GenreId);                       
                        command.ExecuteNonQuery();
                        return (int)command.LastInsertedId;
                    }

                }
                return -1;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }      

        public List<Product> Delete(int code)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(SQL_DELETE_PRODUCT, m_Connection);
                command.Parameters.AddWithValue("@id", code);
                command.ExecuteNonQuery();
                m_Connection.Close();
                List<Product> products = GetAll();
                return products;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }
    }
}
