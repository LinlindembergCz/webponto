using System.Collections.Generic;
using System;
using Pessoal.Domain.Common.Response;

namespace Pessoal.Domain.Commands.Response
{
    public class ColaboradorResponse : BaseResponse
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }

    }
}
