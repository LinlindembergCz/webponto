using System;

namespace PontoEletronico.Application.Commands.Request

{
    public class PontoRequest
    {
        //public string Matricula { get; set; }
        public Guid ColaboradorId { get; set; }         
        public string Nome { get; set; }
    }

    public class MatriculaRequest
    {
        public string Matricula { get; set; }

    }
}
