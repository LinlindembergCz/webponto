using System;
using System.Collections.Generic;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate
{
    public partial class Ponto
    {
        public Guid Id { get; set; }
        public Guid ColaboradorId { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataHora { get; set; }
        public IndicadorEntradaSaida Indicador { get; set; }

        //Inicializei no Fluent API PontoConfiguration

        /*
         public Ponto()
         {
             Id = Guid.NewGuid();
         }
        */

    }



    public enum IndicadorEntradaSaida
    {
        ENTRADA,
        SAIDA
    }
}
