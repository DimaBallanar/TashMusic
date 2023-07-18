using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicServer.Models.Repository;
using MusicServer.Repository;
using System.Data;

namespace MusicServer.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository m_productRepository;

        public ProductController(ProductRepository productRepository)
        {
            m_productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProduct()
        {
            try
            {
                return Ok(m_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }        

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                return Ok(m_productRepository.Put(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }     

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(m_productRepository.Delete(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
