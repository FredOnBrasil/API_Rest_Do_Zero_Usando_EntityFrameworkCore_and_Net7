using DevEventAPI.Entities;
using DevEventAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevEventAPI.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController: ControllerBase
    {
        /// <summary>
        /// conceito de injeção de dependências aplicado na prática:
        /// </summary>
        private readonly EventosDbContext _contexto;
        public EventosController(EventosDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Get api/eventos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            var eventos = _contexto.Eventos; 
            return Ok(eventos);
        }

        /// <summary>
        /// Get api/eventos/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _contexto.Eventos.SingleOrDefault(ev => ev.Id == id);

            if (evento == null)
            {
                return NotFound();
            }
            return Ok();
        }

        /// <summary>
        /// Post api/eventos
        /// </summary>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(Evento evento)
        {
            _contexto.Eventos.Add(evento);
            _contexto.SaveChanges();//para persistir as informações com o EF

            return CreatedAtAction(
                nameof(GetById),
                new {id = evento.Id},
                evento);
        }

        /// <summary>
        /// Put api/eventos/1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="evento"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Evento evento)
        {
            var eventoExistente = _contexto.Eventos.SingleOrDefault(ev => ev.Id == id);

            if (eventoExistente == null)
            {
                return NotFound();
            }

            eventoExistente.Update(evento.Titulo, evento.Descricao, evento.DataInicio, evento.DataFim);

            //para persistir as modificações com o EF
            _contexto.Eventos.Update(eventoExistente);
            _contexto.SaveChanges();

            return NoContent();
        }

        /// <summary>
        /// Delete api/eventos/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var evento = _contexto.Eventos.SingleOrDefault(ev => ev.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            _contexto.Eventos.Remove(evento);

            //para persistir as modificações com o EF
            _contexto.SaveChanges();

            return NoContent();
        }
    }
}
