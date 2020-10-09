using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandCarftBaseServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CatProductController : ControllerBase
    {

        private IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public CatProductController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        [HttpGet]
        [Route("CatProduct/GetCatProductList")]
        public IActionResult GetCatProductList()
        {
            var catProduct = _repository.CatProduct.FindAll().Include(c => c.InverseP).ToList();

            return Ok(catProduct);
        }

        [HttpGet]
        [Route("CatProduct/GetTopCatProductList")]
        public IActionResult GetTopCatProductList()
        {
            try
            {
                var catProduct = _repository.CatProduct.FindAll()
                    .OrderByDescending(c => c.Product.Count)
                    .Select(c => new { c.Id, c.Name }).ToList().Take(7);

                return Ok(catProduct);
            }
            catch (Exception e)
            {

                return BadRequest("Internal server error");
            }

        }

        [HttpGet]
        [Route("CatProduct/GetCatProductListByParentId")]
        public IActionResult GetCatProductListByParentId(long catId)
        {
            var catProduct = _repository.CatProduct.FindByCondition(c => c.Pid == catId)
                .Include(c => c.InverseP).ToList();
              

            return Ok(catProduct);
        }
    }
}
