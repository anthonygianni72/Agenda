
using AgendaDesafio2.Services;
using AgendaDesafioAPI.Data;
using AgendaDesafioAPI.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AgendaDesafioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
       // private readonly DataContext _context;

        private IAgendaService _agendaService;
        private IMapper _mapper;

        public AgendaController(IAgendaService agendaService,IMapper mapper)
        {
            //_context = context;
            _agendaService= agendaService;
            _mapper= mapper;
        }

        // GET: api/<AgendaController>
        [HttpGet]

        public async Task<IActionResult> GetAllAsync()
        {
            var agendas = await _agendaService.GetAllAsync();  // Aguarde a conclusão da tarefa

            if (agendas == null)
            {
                return NotFound();
            }

            return Ok(agendas);
        }

        // GET api/<AgendaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agenda>> GetByIdAsync(int id)
        {
            var agenda = await _agendaService.GetByIdAsync(id);

            if (agenda == null)
            {
                return NotFound();  // Retorna 404 se a agenda não for encontrada
            }

            return Ok(agenda);  // Retorna 200 com os dados da agenda
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] Agenda agendaDto)
        {
            var model = _mapper.Map<Agenda>(agendaDto);

            try
            {
                await _agendaService.CreateAsync(model);
                return  Ok("Contato criado!");
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Agenda agendaDto)
        {
            var model = _mapper.Map<Agenda>(agendaDto);

            try
            {
                await _agendaService.UpdateAsync(id, model);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                await _agendaService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
