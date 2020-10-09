using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using HandCarftBaseServer.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HandCarftBaseServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ProductController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Route("Product/GetAllProductList")]
        public IActionResult GetAllProductList()
        {
            try
            {
                return Ok(_repository.Product.FindByCondition(c => c.Ddate != null && c.DaDate != null).ToList());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        [Route("Product/InsertProduct")]
        public IActionResult InsertProduct()
        {
            Product _product = JsonSerializer.Deserialize<Product>(HttpContext.Request.Form["Product"]);
            var coverImageUrl = HttpContext.Request.Form.Files[0];

            FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(coverImageUrl, 1, "ProductImages");

            Seller seller = new Seller();

            if (uploadFileStatus.Status == 200)
            {
                _product.CoverImageUrl = uploadFileStatus.Path;

                var userid = ClaimPrincipalFactory.GetUserId(User);
                if (_product.SellerId == null || _product.SellerId == 0)
                {
                    seller = _repository.Seller.FindByCondition(c => c.UserId == userid).FirstOrDefault();
                }
                else
                {
                    seller = _repository.Seller.FindByCondition(c => c.Id == _product.SellerId).FirstOrDefault();
                }

                _product.SellerId = seller.Id;

                var catProduct = _repository.CatProduct.FindByCondition(c => c.Id == _product.CatProductId)
                    .FirstOrDefault();
                var counter = (_repository.Product
                                  .FindByCondition(c => c.SellerId == seller.Id && c.CatProductId == catProduct.Id)
                                  .Count() + 1).ToString();
                counter = counter.PadLeft(3, '0');
                _product.Coding = long.Parse(seller.SellerCode.ToString() + catProduct.Coding.ToString() + counter);
                _product.CuserId = userid;
                _product.Cdate = DateTime.Now.Ticks;
                _repository.Product.Create(_product);

                try
                {
                    _repository.Save();

                    return Created("", _product);
                }
                catch (Exception e)
                {

                    FileManeger.FileRemover(new List<string> { uploadFileStatus.Path });
                    return BadRequest(e.Message.ToString());
                }

            }
            else
            {

                return BadRequest("Internal server error");
            }


        }

        [HttpPut]
        [Route("Product/EditProduct")]
        public IActionResult EditProduct(long productId)
        {


            Product _product = JsonSerializer.Deserialize<Product>(HttpContext.Request.Form["Product"]);
            Seller seller = new Seller();
            var userid = ClaimPrincipalFactory.GetUserId(User);

            var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            if (_product.SellerId == null || _product.SellerId == 0)
            {
                seller = _repository.Seller.FindByCondition(c => c.UserId == userid).FirstOrDefault();
            }
            else
            {
                seller = _repository.Seller.FindByCondition(c => c.Id == _product.SellerId).FirstOrDefault();
            }

            if (product.SellerId != seller.Id || product.CatProductId != _product.CatProductId)
            {
                var catProduct = _repository.CatProduct.FindByCondition(c => c.Id == _product.CatProductId)
                    .FirstOrDefault();
                var counter = (_repository.Product
                                   .FindByCondition(c => c.SellerId == seller.Id && c.CatProductId == catProduct.Id)
                                   .Count() + 1).ToString();
                counter = counter.PadLeft(3, '0');
                product.Coding = long.Parse(seller.SellerCode.ToString() + catProduct.Coding.ToString() + counter);

            }

            product.Name = _product.Name;
            product.EnName = _product.EnName;
            product.CatProductId = _product.CatProductId;
            product.Coding = _product.Coding;
            product.Price = _product.Price;
            product.FirstCount = _product.FirstCount;
            product.ProductMeterId = _product.ProductMeterId;
            product.Description = _product.Description;
            product.SellerId = seller.Id;
            product.MuserId = userid;
            product.Mdate = DateTime.Now.Ticks;

            if (HttpContext.Request.Form.Files.Count > 0)
            {
                var coverImageUrl = HttpContext.Request.Form.Files[0];
                var deletedFile = product.CoverImageUrl;
                FileManeger.UploadFileStatus uploadFileStatus = FileManeger.FileUploader(coverImageUrl, 1, "ProductImages");
                if (uploadFileStatus.Status == 200)
                {

                    product.CoverImageUrl = uploadFileStatus.Path;
                    _repository.Product.Update(product);
                    try
                    {
                        _repository.Save();
                        FileManeger.FileRemover(new List<string> { deletedFile });

                        return NoContent();
                    }
                    catch (Exception e)
                    {


                        FileManeger.FileRemover(new List<string> { uploadFileStatus.Path });
                        return BadRequest("Internal server error");
                    }

                }
                else
                {

                    return BadRequest("Internal server error");
                }
            }
            else
            {

                _repository.Product.Update(product);
                try
                {
                    _repository.Save();

                    return NoContent();
                }
                catch (Exception e)
                {


                    return BadRequest("Internal server error");
                }


            }


        }

        [HttpDelete]
        [Route("Product/DeleteProduct")]
        public IActionResult DeleteProduct(long productId)
        {

            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
                if (product == null)
                {
                    return NotFound();

                }
                product.Ddate = DateTime.Now.Ticks;
                product.DuserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Product.Update(product);
                _repository.Save();

                return NoContent();


            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }
        }

        [HttpPut]
        [Route("Product/DeActiveProduct")]
        public IActionResult DeActiveProduct(long productId)
        {

            try
            {
                var product = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
                if (product == null)
                {
                    return NotFound();

                }
                product.DaDate = DateTime.Now.Ticks;
                product.DaUserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Product.Update(product);
                _repository.Save();

                return NoContent();


            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }
        }

        [HttpGet]
        [Route("Product/GetProductById")]
        public IActionResult GetProductById(long productId)
        {
            try
            {
                var result = _repository.Product.FindByCondition(c => c.Id.Equals(productId)).FirstOrDefault();
                if (result.Equals(null))
                {

                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception e)
            {


                return BadRequest("Internal server error");
            }

        }
    }
}
