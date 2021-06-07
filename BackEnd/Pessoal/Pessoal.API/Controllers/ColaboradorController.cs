using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Pessoal.Application.Interfaces;
using System.Threading.Tasks;
using System;
using Pessoal.Application.Commands.Response;
using Pessoal.Application.Commands.Request;
using System.Collections.Generic;

namespace Pessoal.API.Controllers
{
    [Route("colaborador")]
    [ApiController]
    public class ColaboradorController : BaseController
    {
        private IColaboradorFacade _facade;

        public ColaboradorController(IColaboradorFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<List<ColaboradorResponse>>> Get() =>await _facade.FindAllAsync();
  
        [HttpGet("{id}")]
        public ActionResult<ColaboradorResponse> Get(Guid id)
        {
           var p = _facade.FindById(id);
           return Ok( p ); 
        }

        [HttpGet("matricula/{matricula}")]

        public async Task<ActionResult<ColaboradorResponse>> Get(string matricula)
        //public ActionResult<ColaboradorResponse> Get(string matricula)
        {
            var p = await _facade.FindByMatricula(matricula);
            return Ok(p);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ColaboradorRequest request)
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
        public IActionResult Put([FromBody] ColaboradorRequest request)
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
        public IActionResult Delete(Guid id)
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

        [HttpPatch("ativar")]
        public IActionResult Ativar([FromBody] Guid id)
        {
            try
            {
                _facade.Ativar(id);
                return Ok(new { msg = "Ativado com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }

        [HttpPatch("inativar")]
        public IActionResult Inativar([FromBody] Guid id)
        {
            try
            {
                _facade.Inativar(id);
                return Ok(new { msg = "Inativado com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }
    }
}
