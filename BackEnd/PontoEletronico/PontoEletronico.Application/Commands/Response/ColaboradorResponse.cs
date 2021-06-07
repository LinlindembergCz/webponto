using PontoEletronico.Application.Common.Response;
using System;

namespace PontoEletronico.Application.Commands.Response

{
    public class ColaboradorResponse : BaseResponse
    {    
        public Guid id { get; set; }
        public string nome { get; set; }
        public string matricula { get; set; }
    }
}
