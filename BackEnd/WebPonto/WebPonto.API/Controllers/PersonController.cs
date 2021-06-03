using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebPonto.Application.Interfaces;
using WebPonto.Application.Messages.Request;
using WebPonto.Application.Messages.Response;
using System.Threading.Tasks;
using WebPonto.Application.Dtos;
using System;

namespace WebPonto.API.Controllers
{
    [Route("person")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() =>await _facade.FindAllAsync();
  
        [HttpGet("{id}")]
        public ActionResult<PersonDto> Get(int id)
        {
           var p = _facade.FindById(id);
           return Ok( p ); 
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonRequest request)
        {
            try
            {
                _facade.CreateRequest(request);
                 return Ok(new { msg = "criado com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonRequest request)
        {
            try
            {
                 _facade.ModifyRequest(request);
                return Ok(new { msg = "alterado com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _facade.Delete(id);
                return Ok(new { msg = "deletado com sucesso!" });
            }
            catch (Exception e)
            {
               return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }
    }
}
