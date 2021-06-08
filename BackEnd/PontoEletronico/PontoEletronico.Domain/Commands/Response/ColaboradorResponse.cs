using PontoEletronico.Domain.Common.Response;
using System;

namespace PontoEletronico.Domain.Commands.Response

{
    public class ColaboradorResponse : BaseResponse
    {    
        public Guid id { get; set; }
        public string nome { get; set; }
        public string matricula { get; set; }
     
        // public string ativo { get; set; }
    }
}
