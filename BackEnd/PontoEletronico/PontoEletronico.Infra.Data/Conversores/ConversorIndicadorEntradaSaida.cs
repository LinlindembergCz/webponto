using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Enums;

namespace PontoEletronico.Infra.Data.Conversores
{
    public class ConversorIndicadorEntradaSaida : ValueConverter<IndicadorEntradaSaida, string>
    {
        public ConversorIndicadorEntradaSaida() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }
        static string ConverterParaOhBancoDeDados(IndicadorEntradaSaida indicador)
        {
            return indicador.ToString()[0..1];
        }
        static IndicadorEntradaSaida ConverterParaAplicacao(string value)
        {
            var indicador = Enum
                .GetValues<IndicadorEntradaSaida>()
                .FirstOrDefault(p => p.ToString()[0..1] == value);

            return indicador;
        }
    }
}