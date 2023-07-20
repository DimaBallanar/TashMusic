using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MusicServer.Models.Repository;
using MusicServer.Repository;
using System.Data;
using MusicServer.Services;

namespace MusicServer.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService m_productService;

        public ProductController(ProductService product)
        {
            m_productService = product;
        }

        //    [HttpGet]
        //    public IActionResult GetAllProduct()
        //    {
        //        try
        //        {
        //            return Ok(m_productRepository.GetAll());
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }        

        //    [HttpPost]
        //    public IActionResult Post(Product product)
        //    {
        //        try
        //        {
        //            return Ok(m_productRepository.Put(product));
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }     

        //    [HttpDelete("{id}")]
        //    public IActionResult Delete(int id)
        //    {
        //        try
        //        {
        //            return Ok(m_productRepository.Delete(id));
        //        }
        //        catch (Exception ex)
        //        {
        //            return BadRequest(ex.Message);
        //        }
        //    }

        //[HttpPost(Name = "LoadFiles")]
        //public async Task<byte[]> Post()
        //{
        //    try
        //    {
        //        var files = Request.Form.Files;
        //        foreach (var file in files)
        //        {
        //            if (file.Length == 0) continue;

        //            var filePath = Path.Combine("D:\\TestJS\\TashMusic\\Music", file.Name);
        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await file.CopyToAsync(stream);
        //                stream.Close();
        //            }
        //        }
        //        var reFile = Path.Combine("D:\\TestJS\\TashMusic\\Music", files[0].Name);
        //        return System.IO.File.ReadAllBytes(reFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new byte[0];
        //    }
        //}

        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                return Ok(m_productService.PutProduct(product));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<byte[]> GetById(int id)
        {
            try
            {
                var song = m_productService.GetById(id);

                var reFile = Path.Combine("D:\\TestJS\\TashMusic\\Music", song.Name);
                return System.IO.File.ReadAllBytes(reFile);
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }
    }
}
