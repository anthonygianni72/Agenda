using AgendaDesafioAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaDesafio2.Services
{
    public interface IAgendaService
    {

            Task<ActionResult<IEnumerable<Agenda>>> GetAllAsync();
            Task<Agenda> GetByIdAsync(int id);
            Task CreateAsync(Agenda model);
            Task UpdateAsync(int id, Agenda model);
            Task DeleteAsync(int id);


    }
}
