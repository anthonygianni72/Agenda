using AgendaDesafioAPI.Data;
using AgendaDesafioAPI.Models;
using AutoMapper;
using System;
using System.Data.Entity;

namespace AgendaDesafio2.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public AgendaRepository(DataContext context,IMapper mapper)
        {
            _mapper=mapper;
            _context = context;
        }
        public async Task<IEnumerable<Agenda>> GetAllAsync()
        {
            return await _context.Agendas.ToListAsync();
        }

        public async Task<Agenda> GetByIdAsync(int id)
        {
            return await _context.Agendas.FindAsync(id);
        }

        public async Task AddAsync(Agenda agenda)
        {
            await _context.Agendas.AddAsync(agenda);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Agenda agenda)
        {
            _context.Agendas.Update(agenda);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var agenda = await _context.Agendas.FindAsync(id);
            if (agenda != null)
            {
                _context.Agendas.Remove(agenda);
                await _context.SaveChangesAsync();
            }
        }
    }
}
