using PontoEletronico.Domain.Commands.Request;
using PontoEletronico.Domain.Commands.Response;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace PontoEletronico.Application.Interfaces
{
    public interface IPontoFacade
    {
        Task<List<PontoResponse>> FindAllAsync();

        void CreateEntrada(string matricula);

        void CreateSaida(string matricula);

        Task<List<PontosColaboradorResponse>> ListPontosColaborador(string matricula);

    }  
}