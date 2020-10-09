using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using HandCarftBaseServer.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace HandCarftBaseServer.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        public IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ColorController(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }


        [HttpGet]
        [Route("Color/GetColorList")]
        public IActionResult GetColorList()
        {
            var a = User.Identity;

            try
            {
                var res = _repository.Color.FindByCondition(c => (c.DaDate == null) && (c.Ddate == null)).ToList();
                var result = _mapper.Map<List<ColorDto>>(res);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpPost]
        [Route("Color/AddColor")]
        public IActionResult AddColor(ColorDto color)
        {


            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _color = _mapper.Map<Color>(color);
                _color.Cdate = DateTime.Now.Ticks;
                _color.CuserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Color.Create(_color);
                _repository.Save();
                return Created("", _color);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Color/UpdateColor")]
        public IActionResult UpdateColor(ColorDto color)
        {


            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var _color = _repository.Color.FindByCondition(c => c.Id == color.Id).FirstOrDefault();
                if (_color == null) return NotFound();
                _color.Name = color.Name;
                _color.ColorCode = color.ColorCode;
                _color.Rkey = color.Rkey;
                _color.Mdate = DateTime.Now.Ticks;
                _color.MuserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Color.Update(_color);
                _repository.Save();
                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("Color/DeleteColor")]
        public IActionResult DeleteColor(long id)
        {

            try
            {

                var _color = _repository.Color.FindByCondition(c => c.Id == id).FirstOrDefault();
                if (_color == null) return NotFound();
                _color.Ddate = DateTime.Now.Ticks;
                _color.DuserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Color.Update(_color);
                _repository.Save();
                return NoContent();


            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error");
            }
        }

        [Authorize]
        [HttpPut]
        [Route("Color/DeActiveColor")]
        public IActionResult DeActiveColor(long id)
        {

            try
            {
                var _color = _repository.Color.FindByCondition(c => c.Id == id).FirstOrDefault();
                if (_color == null) return NotFound();
                _color.DaDate = DateTime.Now.Ticks;
                _color.DaUserId = ClaimPrincipalFactory.GetUserId(User);
                _repository.Color.Update(_color);
                _repository.Save();
                return NoContent();

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error");
            }
        }
    }
}
