using DataAccesLayer.Models;
using DataAccesLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_TEST_BASE_MS_STAKEHOLDERS.DTOs;

namespace NET_TEST_BASE_MS_STAKEHOLDERS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiariosController : ControllerBase
    {
        private readonly IBeneficiarioService _beneficiarioService;
        public BeneficiariosController(IBeneficiarioService beneficiarioService)
        {
            _beneficiarioService = beneficiarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBeneficiarios()
        {
            var beneficiarios = await _beneficiarioService.GetAllBeneficiarios();
            return Ok(beneficiarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBeneficiarioById(int id)
        {
            var beneficiario = await _beneficiarioService.GetBeneficiarioById(id);
            if (beneficiario == null) return NotFound();
            return Ok(beneficiario);
        }
        [HttpPost]
        public async Task<IActionResult> AddPago([FromBody] BeneficiarioDTO beneficiarioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var beneficiario = new Beneficiario
            {
                Nombre=beneficiarioDto.nombre
            };
            await _beneficiarioService.AddBeneficiario(beneficiario);
            return CreatedAtAction(nameof(GetBeneficiarioById), new { id = beneficiario.Id }, beneficiario);
        }

        [HttpPut("{id}/nombre")]
        public async Task<IActionResult> UpdateBeneficiarioNombre(int id, [FromBody] string nuevonombre)
        {
            await _beneficiarioService.UpdateBeneficiarioNombre(id,nuevonombre);
            return NoContent();
        }

    }
}
