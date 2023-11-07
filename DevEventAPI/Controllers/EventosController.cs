using DevEventAPI.Entities;
using DevEventAPI.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevEventAPI.Controllers
{
    [ApiController]
    [Route("api/eventos")]
    public class EventosController : ControllerBase
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
        /// Consulta todos os eventos:  [Rota = Get api/eventos]
        /// </summary>
        /// <returns>ok</returns>
        /// /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var eventos = _contexto.Eventos;
            return Ok(eventos);
        }

        /// <summary>
        /// Consulta evento por id: [Rota = Get api/eventos/1]
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <returns>ok</returns>
        /// /// <response code="200">Sucesso</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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
        /// Cadastro de eventos: [Rota = Post api/eventos]
        /// </summary>
        /// <remarks>
        /// {
        ///     "titulo": "string",
        ///     "descricao": "string",
        ///     "dataInicio": "2023-11-07T19:00:04.105Z",
        ///     "dataFim": "2023-11-07T19:00:04.105Z",
        ///     "organizador": "string",
        ///     "dataCriacao": "2023-11-07T19:00:04.105Z"
        /// }
        /// </remarks>
        /// <param name="evento">Dados do Evento</param>
        /// <returns>Evento recém criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(Evento evento)
        {
            _contexto.Eventos.Add(evento);
            _contexto.SaveChanges();//para persistir as informações com o EF

            return CreatedAtAction(
                nameof(GetById),
                new { id = evento.Id },
                evento);
        }

        /// <summary>
        /// Atualização de Eventos: [Rota = Put api/eventos/1]
        /// </summary>
        /// <param name="id">Id do evento</param>
        /// <param name="evento">Dados do Evento</param>
        /// <returns>No Content</returns>
        /// /// <response code="204">Sucesso</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
        /// Apaga registro usando id: [Rota = Delete api/eventos/1]
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No Content</returns>
        /// /// <response code="204">Sucesso</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
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
