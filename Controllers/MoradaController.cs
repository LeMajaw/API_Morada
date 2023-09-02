using API_Morada.Models;
using API_Morada.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_Morada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MoradaController : ControllerBase
    {
        private IMoradaService _moradaService;
        private readonly IConfiguration _configuration;

        public MoradaController(IConfiguration configuration, IMoradaService moradaService)
        {
            _configuration = configuration;
            _moradaService = moradaService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Morada>>> GetMoradas()
        {
            try
            {
                var moradas = await _moradaService.GetMorada();
                return Ok(moradas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Moradas!");
            }
        }

        [HttpGet("{id:int}", Name = "GetMorada")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Morada>> GetMorada(int id)
        {
            try
            {
                var morada = await _moradaService.GetMorada(id);

                if (morada == null)
                    return NotFound($"Não existe Morada com o id: {id}.");

                return Ok(morada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Moradas!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Morada morada)
        {
            try
            {
                await _moradaService.InsertMorada(morada);

                return CreatedAtRoute(nameof(GetMorada), new { id = morada.id }, morada);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao incluir Morada!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Morada morada)
        {
            try
            {
                if (morada.id == id)
                {
                    await _moradaService.UpdateMorada(morada);
                    return Ok($"A Morada com id = {id} foi atualizada com sucesso!");
                }
                else
                    return BadRequest("Dados inconsistentes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao alterar Moradas!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var morada = await _moradaService.GetMorada(id);

                if (morada != null)
                {
                    await _moradaService.DeleteMorada(morada);
                    return Ok($"A Morada de id = {id} foi excluída com sucesso!");
                }
                else
                    return NotFound($"Morada de id = {id} nâo encontrada!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao deletar Morada!");
            }
        }
    }
}