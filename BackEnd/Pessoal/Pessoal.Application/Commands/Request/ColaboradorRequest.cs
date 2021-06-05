using System;

namespace Pessoal.Application.Commands.Request

{
    public class ColaboradorRequest
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; set; }

    }
}
