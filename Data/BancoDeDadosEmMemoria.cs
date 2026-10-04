using LHPets.Models;

namespace LHPets.Data
{
    public class BancoDeDadosEmMemoria
    {
        public static List<Cliente> Clientes { get; set; } = new List<Cliente>
        {
            new Cliente { Id = 1, Nome = "Maria Silva", Cpf = "123.456.789-00", Email = "maria@email.com" }
        };

        public static List<Pet> Pets { get; set; } = new List<Pet>
        {
            new Pet { Id = 1, Nome = "Rex", Especie = "Cachorro", ClienteId = 1 }
        };
    }
}