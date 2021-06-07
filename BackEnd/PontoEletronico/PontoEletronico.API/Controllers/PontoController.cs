using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Application.Interfaces;
using System.Threading.Tasks;
using System;
using PontoEletronico.Application.Commands.Response;
using PontoEletronico.Application.Commands.Request;
using System.Collections.Generic;

namespace Pessoal.API.Controllers
{
    [Route("apontador")]
    [ApiController]
    public class PontoController : BaseController
    {
        private IPontoFacade _facade;

        public PontoController(IPontoFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<List<PontoResponse>>> Get() => await _facade.FindAllAsync();

        [HttpPost("entrada")]
        public IActionResult RegistrarEntrada([FromBody] MatriculaRequest request)
        {
            try
            {            
                 _facade.CreateEntrada(request.Matricula);
                return Ok(new { msg = "entrada registrada com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }

        [HttpPost("saida")]
        public IActionResult RegistrarSaida([FromBody] MatriculaRequest request)
        {
            try
            {
                _facade.CreateSaida(request.Matricula);
                return Ok(new { msg = "saida registrada com sucesso!" });
            }
            catch (Exception e)
            {
                return new ObjectResult("Falhou! Mensagem: " + e.Message);
            }
        }


    }
}
