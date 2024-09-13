using AgendaDesafioAPI.Models;

namespace AgendaDesafio2.Repositories
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Agenda>> GetAllAsync();
        Task<Agenda> GetByIdAsync(int id);
        Task AddAsync(Agenda agenda);
        Task UpdateAsync(Agenda agenda);
        Task DeleteAsync(int id);
    }
}
