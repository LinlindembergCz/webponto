using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PontoEletronico.Application.Interfaces;
using System.Threading.Tasks;
using System;
using PontoEletronico.Domain.Commands.Response;
using PontoEletronico.Domain.Commands.Request;
using System.Collections.Generic;

namespace PontoEletronico.API.Controllers
{
    [Route("listapontos")]
    [ApiController]
    public class ListPontosController : BaseController
    {
        private IPontoFacade _facade;

        public ListPontosController(IPontoFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet("{matricula}")]
        public async Task<ActionResult<List<PontosColaboradorResponse>>> Get(string matricula) =>
             await _facade.ListPontosColaborador(matricula);
    }
}
