using System.Collections.Generic;

namespace PontoEletronico.Domain.Common.Response
{
    public abstract class BaseResponse
    {
        public bool Success { get; set; } = true;

        public IEnumerable<object> Errors { get; set; } = null;
    }
}
