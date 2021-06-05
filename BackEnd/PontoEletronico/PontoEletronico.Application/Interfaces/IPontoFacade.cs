using PontoEletronico.Application.Commands.Request;
using PontoEletronico.Application.Commands.Response;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace PontoEletronico.Application.Interfaces
{
    public interface IPontoFacade
    {
        Task<List<PontoResponse>> FindAllAsync();
               
        void CreateEntrada(PontoRequest entity);

        void CreateSaida(PontoRequest entity);
    }
}