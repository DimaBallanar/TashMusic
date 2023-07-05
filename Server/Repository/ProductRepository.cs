using MySql.Data.MySqlClient;
using MusicServer.Models.Repository;

namespace MusicServer.Repository
{
    public class ProductRepository : BaseRepository
    {
      
        private readonly string SQL_SELECT_GET_ALL = "Select id,name,description,price,brand_id,category_id from Product";
        private readonly string SQL_PUT_ITEM = "insert into Product(name,description,price,brand_id,category_id) values (@name, @description, @price, @brand_id, @category_id)";
        private readonly string SQL_UPDATE_PRODUCT = "UPDATE Product Set name=@name, description=@description, price=@price,brand_id=@brand_id, category_id=@category_id where Id={0}"; 
        private readonly string SQL_DELETE_PRODUCT = "delete from Product where Id=@id;";
        private readonly string SQL_SELECT_FOR_VIEW_PRODUCTS= @"select c.name as Продукт ,description as описание,price  as цена,b.name as бренд,c.Name as категория from product p
                                                                inner join brand b
                                                                on b.ID=p.brand_id
                                                                inner join category c
                                                                on c.ID= p.category_id;";
                                                                
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
                        Description = reader.GetString(2),
                        Price = reader.GetDecimal(3),
                        Brand = reader.GetInt32(4).ToString(),
                        Category = reader.GetInt32(5).ToString()
                        //Brand =(from b in brands where b.Id==reader.GetInt32(4) select b.Name).ToString(),
                        //Category= (from b in categories where b.Id == reader.GetInt32(5) select b.Name).ToString()

                    });
                }
                return products;
            }
            catch (MySqlException e)
            {
                throw e;
            }
        }
        public List<Product> GetAll(int id)
        {
            try
            {
                if(id<=0)
                m_Connection.Open();
                MySqlCommand cmd = new MySqlCommand(SQL_SELECT_GET_ALL, m_Connection);
                List<Product> products = new List<Product>();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetInt32(0) == id)
                    {
                        products.Add(new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Price = reader.GetDecimal(3),
                            Brand = reader.GetString(4),
                            Category = reader.GetString(5)
                        });
                    }
                }
                return products;
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
                        command.Parameters.AddWithValue("@description", product.Description);
                        command.Parameters.AddWithValue("@price", product.Price);
                        command.Parameters.AddWithValue("@brand_id", product.Brand);
                        command.Parameters.AddWithValue("@category_id", product.Category);
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

        public List<Product> Update(Product product)
        {
            try
            {
                m_Connection.Open();
                MySqlCommand command = new MySqlCommand(string.Format(SQL_UPDATE_PRODUCT, product.Id), m_Connection);
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@brand_id", product.Brand);
                command.Parameters.AddWithValue("@category_id", product.Category);
                command.ExecuteNonQuery();
                m_Connection.Close();
                List<Product> products = GetAll();
                return products;
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
