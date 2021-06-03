using WebPonto.Application.Dtos;
using WebPonto.Application.Messages.Request;
using WebPonto.Application.Messages.Response;
using System.Threading.Tasks;
using System;

namespace WebPonto.Application.Interfaces
{
    public interface IPersonFacade
    {

        Task<PersonResponse> FindAllAsync();

        PersonDto FindById(Guid id);

        void CreateRequest(PersonRequest entity);

        void ModifyRequest(PersonRequest entity);

        void Delete(Guid id);
    }
}