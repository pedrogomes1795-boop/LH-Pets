using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        // Método GET: Lista todos os clientes
        [HttpGet]
        public IActionResult ListarClientes()
        {
            return Ok(BancoDeDadosEmMemoria.Clientes);
        }

        // Método GET por ID: Procura um cliente específico pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterClientePorId(int id)
        {
            var cliente = BancoDeDadosEmMemoria.Clientes.FirstOrDefault(c => c.Id == id);
            
            if (cliente == null)
            {
                return NotFound(new { mensagem = "Cliente não encontrado." });
            }

            return Ok(cliente);
        }

        // Método POST: Adiciona um novo cliente
        [HttpPost]
        public IActionResult CadastrarCliente([FromBody] Cliente cliente)
        {
            cliente.Id = BancoDeDadosEmMemoria.Clientes.Count + 1;
            BancoDeDadosEmMemoria.Clientes.Add(cliente);
            return Ok(cliente);
        }
    }
}