using WebPonto.Application.Dtos;
using WebPonto.Application.Messages.Request;
using WebPonto.Application.Messages.Response;
using System.Threading.Tasks;

namespace WebPonto.Application.Interfaces
{
    public interface IPersonFacade
    {

        Task<PersonResponse> FindAllAsync();

        PersonDto FindById(int id);

        void CreateRequest(PersonRequest entity);

        void ModifyRequest(PersonRequest entity);

        void Delete(int id);
    }
}