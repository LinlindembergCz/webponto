using System.Collections.Generic;
using System;
using Pessoal.Application.Common.Response;

namespace Pessoal.Application.Commands.Response
{
    public class ColaboradorResponse : BaseResponse
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

    }
}
