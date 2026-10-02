using MinhaApi.Models;
using MinhaApi.Repositories;

namespace MinhaApi.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _repository;

    // Injeta o Repositório no construtor da classe
    public ClienteService(IClienteRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Cliente> GetAll()
    {
        return _repository.GetAll();
    }

    public Cliente? GetById(int id)
    {
        return _repository.GetById(id);
    }

    public Cliente Create(Cliente cliente)
    {
        // Regra de Negócio: Nome e E-mail são obrigatórios
        if (string.IsNullOrWhiteSpace(cliente.Nome))
            throw new ArgumentException("O nome do cliente é obrigatório.");

        if (string.IsNullOrWhiteSpace(cliente.Email))
            throw new ArgumentException("O e-mail do cliente é obrigatório.");

        _repository.Add(cliente);
        return cliente;
    }

    public Cliente? Update(int id, Cliente cliente)
    {
        // Regra de Negócio: Verifica se o cliente existe antes de atualizar
        var clienteExistente = _repository.GetById(id);
        if (clienteExistente == null)
            return null;

        cliente.Id = id;
        _repository.Update(cliente);
        return cliente;
    }

    public bool Delete(int id)
    {
        // Regra de Negócio: Verifica se o cliente existe antes de deletar
        var clienteExistente = _repository.GetById(id);
        if (clienteExistente == null)
            return false;

        _repository.Delete(id);
        return true;
    }
}