using System;
using PontoEletronico.Domain.Common.Response;

namespace PontoEletronico.Domain.Commands.Response
{
    public class PontosColaboradorResponse : BaseResponse
    {
        public string Nome { get; set; }
        public string Dia { get; set; }       
        public Decimal Horas { get; set; }
    }
}
