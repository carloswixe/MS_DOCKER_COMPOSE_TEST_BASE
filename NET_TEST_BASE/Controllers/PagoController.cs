using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NET_TEST_BASE.DTOs;
using DataAccesLayer.Models;
using DataAccesLayer.Services;

namespace NET_TEST_BASE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPagos()
        {
            var pagos = await _pagoService.GetAllPagos();
            return Ok(pagos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagoById(int id)
        {
            var pago = await _pagoService.GetPagoById(id);
            if (pago == null) return NotFound();
            return Ok(pago);
        }

        [HttpPost]
        public async Task<IActionResult> AddPago([FromBody] PagoDto pagoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var pago = new Pago
            {
                Concepto = pagoDto.Concepto,
                CantidadProductos = pagoDto.CantidadProductos,
                OrdenanteId = pagoDto.OrdenanteId,
                BeneficiarioId = pagoDto.BeneficiarioId,
                MontoTotal = pagoDto.MontoTotal,
                Estatus = pagoDto.Estatus // "Pendiente" por defecto si no se proporciona otro valor
            };
            await _pagoService.AddPago(pago);
            return CreatedAtAction(nameof(GetPagoById), new { id = pagoDto.Concepto }, pagoDto);
        }

        [HttpPut("{id}/estatus")]
        public async Task<IActionResult> UpdatePagoEstatus(int id, [FromBody] string nuevoEstatus)
        {
            var listaestatuspermitidos = new List<string>();
            listaestatuspermitidos.Add(Estatuspermitidos.Pendiente.ToString().ToLower());
            listaestatuspermitidos.Add(Estatuspermitidos.Pagado.ToString().ToLower());
            listaestatuspermitidos.Add(Estatuspermitidos.Rechazado.ToString().ToLower());
            if (listaestatuspermitidos.Contains(nuevoEstatus.ToLower()))
            {
                await _pagoService.UpdatePagoEstatus(id, utils.ToPascalCase(nuevoEstatus));
                return NoContent();
            }
            else {
                return BadRequest("El estatus enviado no es permitido, utilice uno de los estatus permitidos:  Pendiente, Pagado, Rechazado");
            }
        }
    }
}
