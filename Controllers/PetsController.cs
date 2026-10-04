using LHPets.Data;
using LHPets.Models;
using Microsoft.AspNetCore.Mvc;

namespace LHPets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        // GET /api/pets ➔ Retorna todos os pets cadastrados
        [HttpGet]
        public IActionResult ListarPets()
        {
            return Ok(BancoDeDadosEmMemoria.Pets);
        }

        // GET /api/pets/{id} ➔ Retorna um pet específico pelo ID
        [HttpGet("{id}")]
        public IActionResult ObterPetPorId(int id)
        {
            var pet = BancoDeDadosEmMemoria.Pets.FirstOrDefault(p => p.Id == id);
            
            if (pet == null)
            {
                return NotFound(new { mensagem = "Pet não encontrado." });
            }

            return Ok(pet);
        }

        // GET /api/pets/cliente/{clienteId} ➔ Retorna apenas os pets pertencentes ao cliente informado
        [HttpGet("cliente/{clienteId}")]
        public IActionResult ListarPetsPorCliente(int clienteId)
        {
            var petsDoCliente = BancoDeDadosEmMemoria.Pets.Where(p => p.ClienteId == clienteId).ToList();

            if (!petsDoCliente.Any())
            {
                return NotFound(new { mensagem = "Nenhum pet encontrado para este cliente." });
            }

            return Ok(petsDoCliente);
        }

        // POST /api/pets ➔ Adiciona um novo pet vinculado a um cliente (ClienteId)
        [HttpPost]
        public IActionResult CadastrarPet([FromBody] Pet pet)
        {
            pet.Id = BancoDeDadosEmMemoria.Pets.Count + 1;
            BancoDeDadosEmMemoria.Pets.Add(pet);
            return Ok(pet);
        }
    }
}