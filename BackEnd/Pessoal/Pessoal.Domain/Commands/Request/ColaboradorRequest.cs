using System;

namespace Pessoal.Domain.Commands.Request

{
    public class ColaboradorRequest
    {
        public Guid id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; set; }

    }
}
