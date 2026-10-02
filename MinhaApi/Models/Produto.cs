namespace MinhaApi.Models;

public class Produto
{
    //Identificador único
    public int Id {get; set;}

    //Nome do produto
    public string Nome {get; set;}
        = string.Empty;

    //Precisão monetária
    public decimal Preco {get; set;}

    //Quantidade no estoque
    public int Estoque {get; set;}

    //Soft delete
    public bool Ativo {get; set;}
        = true;
}