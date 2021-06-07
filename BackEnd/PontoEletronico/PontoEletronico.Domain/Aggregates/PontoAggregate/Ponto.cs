using System;
using System.Collections.Generic;
using PontoEletronico.Domain.Enums;

namespace PontoEletronico.Domain.Aggregates.PontoAggregate
{
    public partial class Ponto
    {
        public Guid Id { get; set; }
        public Guid ColaboradorId { get; set; }
        public string Nome { get; set; }
        public DateTimeOffset DataHora { get; set; }
        public IndicadorEntradaSaida Indicador { get; set; }
        public bool PontuouSaida()
        {
           return this.Indicador == IndicadorEntradaSaida.SAIDA;
        }

        public bool PontuouEntrada()
        {
           return Indicador == IndicadorEntradaSaida.ENTRADA;
        }

        //Inicializei no Fluent API PontoConfiguration
        /*
         public Ponto()
         {
             Id = Guid.NewGuid();
         }
        */

    }
   
}
