using PontoEletronico.Domain.Commands.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PontoEletronico.Domain.Aggregates.Colaborador.Interfaces
{
    public interface IColaboradorService
    {
        Task<ColaboradorResponse> FindColaboradorByMatricula(string matricula);


    }
}
