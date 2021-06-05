using System.Collections.Generic;
using System;
using PontoEletronico.Application.Common.Response;

namespace PontoEletronico.Application.Commands.Response
{
    public class PontoResponse : BaseResponse
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataHora { get; set; }
    }
}
