using API_Morada.Models;
using API_Morada.Services;
using Microsoft.AspNetCore.Mvc;

namespace API_Morada.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _loginService;
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
            _configuration = configuration;
            _loginService = loginService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IAsyncEnumerable<Login>>> GetLogins()
        {
            try
            {
                var logins = await _loginService.GetLogins();
                return Ok(logins);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Logins!");
            }
        }

        [HttpGet("{id:int}", Name = "GetLogin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Login>> GetLogin(int id)
        {
            try
            {
                var login = await _loginService.GetLogin(id);

                if (login == null)
                    return NotFound($"Não existe Login com o id: {id}.");

                return Ok(login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Logins!");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Login login)
        {
            try
            {
                await _loginService.InsertLogin(login);

                return CreatedAtRoute(nameof(GetLogin), new { id = login.id }, login);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao incluir Logins!");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Login login)
        {
            try
            {
                if (login.id == id)
                {
                    await _loginService.UpdateLogin(login);
                    return Ok($"O Login com id = {id} foi atualizado com sucesso!");
                }
                else
                    return BadRequest("Dados inconsistentes.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao alterar Logins!");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var login = await _loginService.GetLogin(id);

                if (login != null)
                {
                    await _loginService.DeleteLogin(login);
                    return Ok($"O Login de id = {id} foi excluído com sucesso!");
                }
                else
                    return NotFound($"Login de id = {id} nâo encontrado!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao excluir Logins!");
            }
        }

    }
}
