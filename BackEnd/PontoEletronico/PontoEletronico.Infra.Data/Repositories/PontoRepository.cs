using PontoEletronico.Domain.Aggregates.PontoAggregate;
using PontoEletronico.Domain.Aggregates.PontoAggregate.Interfaces;
using PontoEletronico.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontoEletronico.Domain.Enums;
using PontoEletronico.Domain.Commands.Response;
using System.Data;
using System.Data.Common;

namespace PontoEletronico.Infra.Data.Repositories
{
    public class PontoRepository : IPontoRepository
    {
        private readonly PontoContext _context;

        public PontoRepository(PontoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ICollection<Ponto>> FindAllAsync() =>
           await _context.Ponto.AsNoTracking().ToListAsync();

        public async Task<ICollection<PontosColaboradorResponse>> ListPontosColaborador(Guid colaboradorid)
        {
            var Id = colaboradorid.ToString();          

            var con = _context.Database.GetDbConnection();
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = @" select  distinct
             Nome,  
              FORMAT(DataHora, 'yyyy-MM-dd') Dia,
             cast( ( datediff(second,
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno = 1 and indicador = 'E' and colaboradorId = ap.colaboradorId), 'HH:mm'), 
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno  = 1 and indicador = 'S' and colaboradorId = ap.colaboradorId), 'HH:mm') )/3600.0 ) as decimal (3,2)) + 
             cast( ( datediff(second, 
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno = 2 and indicador = 'E' and colaboradorId = ap.colaboradorId), 'HH:mm'), 
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno = 2 and indicador = 'S' and colaboradorId = ap.colaboradorId), 'HH:mm') )/3600.0 ) as decimal (3,2)) + 
             cast( ( datediff(second, 
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno = 3 and indicador = 'E' and colaboradorId = ap.colaboradorId), 'HH:mm'), 
             FORMAT( (Select DataHora from apontamentos ap1 where 
                     ap1.turno = 3 and indicador = 'S' and colaboradorId = ap.colaboradorId), 'HH:mm') )/3600.0 ) as decimal (3,2)) As Horas  " +
    
            $" from apontamentos ap where ColaboradorId = {Id}";

            DbDataReader rdr = await cmd.ExecuteReaderAsync(CommandBehavior.SequentialAccess);        
            
            List<PontosColaboradorResponse> Pontos = new List<PontosColaboradorResponse>();
            while (await rdr.ReadAsync())
            {
                 Pontos.Add(new PontosColaboradorResponse {
                    Nome = rdr.GetString(0),
                    Dia = rdr.GetString(1),
                    Horas = rdr.GetDecimal(2),
                });
            }
            return Pontos;                     
        }
        public void Create(Ponto entity)
        {
            _context.Ponto.Add(entity);
            _context.SaveChanges();
        }
        public Ponto FindLastPontoOfDay(Guid colaboradorId)
        {
            Ponto ponto = _context.Ponto.OrderByDescending(p => p.DataHora).AsNoTracking().
                                         FirstOrDefault(p =>
                                        (p.ColaboradorId == colaboradorId) &&
                                        (p.DataHora.Date == DateTime.Now.Date));       
            return ponto;
        }        

    }
}
