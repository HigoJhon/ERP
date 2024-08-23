using backend.Models;
using backend.Repository;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        protected readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_clientRepository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            try
            {
                return Ok(_clientRepository.GetClientById(id));
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost("add")]
        public IActionResult AddClient([FromBody] Clients client)
        {
            var emailExists = _clientRepository.GetAll().FirstOrDefault(x => x.Email == client.Email);

            if (emailExists != null)
            {
                return BadRequest("Email already exists");
            }
            
            try
            {
                return Ok(_clientRepository.AddClient(client));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateClient(int id, [FromBody] Clients client)
        {
            if (id != client.Id)
            {
                return BadRequest("Id mismatch");
            }

            try
            {
                return Ok(_clientRepository.UpdateClient(client));
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            try
            {
                return Ok( new { message = "User removed successfully" });
            }
            catch (System.Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}