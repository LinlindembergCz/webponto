using System;

namespace PontoEletronico.Domain.Commands.Request

{
    public class PontoRequest
    {
        public Guid ColaboradorId { get; set; }
        public string Nome { get; set; }
    } 
}
