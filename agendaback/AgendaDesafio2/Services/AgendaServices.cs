using AgendaDesafioAPI.Data;
using AgendaDesafioAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AgendaDesafio2.Services
{
    
    public class AgendaServices : IAgendaService
    {
        private DataContext _context;
        private readonly IMapper _mapper;
        public AgendaServices(DataContext context,IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<ActionResult<IEnumerable<Agenda>>> GetAllAsync()
        {
            return await _context.Agendas.ToListAsync();
        }

        public async Task<Agenda> GetByIdAsync(int id)
        {
            return await _context.Agendas.FindAsync(id);
        }


        public async Task CreateAsync(Agenda model)
        {
            // validate
            if (await _context.Agendas.AnyAsync(x => x.Email == model.Email))
                throw new Exception("Usuario com o email: '" + model.Email + "' já existe.");

            // map model to new user object
            var user = _mapper.Map<Agenda>(model);

            // save user
            await _context.Agendas.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, Agenda model)
        {
            var user = await _context.Agendas.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Agenda não encontrada.");
            }

            if (model.Email != user.Email && await _context.Agendas.AnyAsync(x => x.Email == model.Email))
                throw new Exception("Usuario com o email: '" + model.Email + "' já existe.");

            //_mapper.Map(model, user);
            user.Nome = model.Nome;
            user.Email = model.Email;
            user.Telefone = model.Telefone;
            // Informar ao contexto que a entidade foi modificada
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.Agendas.FindAsync(id);
            if (user == null)
            {
                throw new Exception("Agenda não encontrada.");
            }

            _context.Agendas.Remove(user);
            await _context.SaveChangesAsync();
        }
        private Agenda getAgenda(int id)
        {
            var agenda = _context.Agendas.Find(id);
            if (agenda == null) throw new KeyNotFoundException("User não encontrado.");
            return agenda;
        }

    }
}
