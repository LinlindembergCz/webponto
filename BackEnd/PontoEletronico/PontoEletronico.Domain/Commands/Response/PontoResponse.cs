using System;
using PontoEletronico.Domain.Common.Response;

namespace PontoEletronico.Domain.Commands.Response
{
    public class PontoResponse : BaseResponse
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataHora { get; set; }
    }
}
