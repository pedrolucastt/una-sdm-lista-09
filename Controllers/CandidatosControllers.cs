using Microsoft.AspNetCore.Mvc;
using una_sdm_lista_09.Data;
using una_sdm_lista_09.Models;

namespace una_sdm_lista_09.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        public ActionResult<IEnumerable<Candidato>> Get()
        {
            return _context.Candidatos.ToList();
        }

        // POST
        [HttpPost]
        public ActionResult Post(Candidato candidato)
        {
            if (_context.Candidatos.Any(c => c.Numero == candidato.Numero))
                return BadRequest("Número já cadastrado");

            _context.Candidatos.Add(candidato);
            _context.SaveChanges();

            return Ok(candidato);
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id, Candidato candidato)
        {
            var existente = _context.Candidatos.Find(id);
            if (existente == null) return NotFound();

            existente.Nome = candidato.Nome;
            existente.ViceNome = candidato.ViceNome;
            existente.Numero = candidato.Numero;
            existente.Partido = candidato.Partido;

            _context.SaveChanges();
            return Ok(existente);
        }

        // DELETE
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var candidato = _context.Candidatos.Find(id);
            if (candidato == null) return NotFound();

            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();

            return NoContent();
        }

        // FILTRO POR PARTIDO
        [HttpGet("partido/{nomeDoPartido}")]
        public ActionResult GetPorPartido(string nomeDoPartido)
        {
            var lista = _context.Candidatos
                .Where(c => c.Partido == nomeDoPartido)
                .ToList();

            return Ok(lista);
        }
    }
}