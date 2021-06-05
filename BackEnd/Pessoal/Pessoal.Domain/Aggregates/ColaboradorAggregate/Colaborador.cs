using System;
using System.Collections.Generic;

namespace Pessoal.Domain.Aggregates.ColaboradorAggregate
{
    public partial class Colaborador 
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public bool Ativo { get; private set; }
   
        public void Ativar()
        {
            Ativo = true;
        }

        public void Inativar()
        {
            Ativo = false;
        }

    }
}
