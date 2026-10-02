using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IProdutoService
{
    IEnumerable<Produto> GetAll();
    Produto? GetById(int d);
    Produto Create(Produto produto);
    Produto? Update(int d, Produto produto);
    bool    Delete(int d);
}


