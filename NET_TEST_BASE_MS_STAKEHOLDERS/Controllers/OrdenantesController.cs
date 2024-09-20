using DataAccesLayer.Models;
using DataAccesLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_TEST_BASE_MS_STAKEHOLDERS.DTOs;
using NET_TEST_BASE_MS_STAKEHOLDERS.Services;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrdenantesController : ControllerBase
    {
        private readonly IOrdenanteService _ordenanteService;
        public OrdenantesController(IOrdenanteService ordenanteService)
        {
            _ordenanteService = ordenanteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrdenantes()
        {
            var Ordenantes = await _ordenanteService.GetAllOrdenantes();
            return Ok(Ordenantes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrdenanteById(int id)
        {
            var Ordenante = await _ordenanteService.GetOrdenanteById(id);
            if (Ordenante == null) return NotFound();
            return Ok(Ordenante);
        }
        [HttpPost]
        public async Task<IActionResult> AddPago([FromBody] OrdenanteDTO OrdenanteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var Ordenante = new Ordenante
            {
                Nombre = OrdenanteDto.nombre
            };
            await _ordenanteService.AddOrdenante(Ordenante);
            return CreatedAtAction(nameof(GetOrdenanteById), new { id = Ordenante.Id }, Ordenante);
        }

        [HttpPut("{id}/nombre")]
        public async Task<IActionResult> UpdateOrdenanteNombre(int id, [FromBody] string nuevonombre)
        {
            await _ordenanteService.UpdateOrdenanteNombre(id, nuevonombre);
            return NoContent();
        }
    }
}
