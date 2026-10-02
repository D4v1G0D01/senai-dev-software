using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IClienteService
{
    IEnumerable<Cliente> GetAll();
    Cliente? GetById(int d);
    Cliente Create(Cliente cliente);
    Cliente? Update(int d, Cliente liente);
    bool    Delete(int d);
}


