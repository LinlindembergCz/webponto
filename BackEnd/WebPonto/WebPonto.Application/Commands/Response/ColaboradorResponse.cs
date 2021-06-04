using System.Collections.Generic;
using System;
using WebPonto.Application.Common.Response;

namespace WebPonto.Application.Commands.Response
{
    public class ColaboradorResponse : BaseResponse
    {
        //public List<ColaboradorDto> ColaboradorObjects { get; set; }
        public Guid id { get; set; }
        public string Nome { get; set; }
    }
}
