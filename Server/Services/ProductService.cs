using MusicServer.Models.Repository;
using MusicServer.Repository;

namespace MusicServer.Services
{
    public class ProductService
    {
        private readonly ProductRepository m_ProductRepository;

        public ProductService(ProductRepository productRepository)
        {
            m_ProductRepository = productRepository;
        }

        public List<Product> GetAll()
        {
            return m_ProductRepository.GetAll();
        }   
        
        public Product GetById(int id)
        {
            return m_ProductRepository.GetById(id);
        }

        public int PutProduct(Product product)
        { 
            return m_ProductRepository.Put(product);
        }      

        public List<Product> DeleteProduct(int id)
        {
            return m_ProductRepository.Delete(id);
        }

    }
}
