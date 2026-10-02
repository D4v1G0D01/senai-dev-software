using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers;
//Habilita validações automáticas
[ApiController]

//URL base = api/produto

[Route("api/[controller]")]
public class ProdutoController
    //Herda helpers HTTP
    :ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(
        //Injeção de dependência
        IProdutoService service)
        => _service = service;
    
    // GET /api/produto
    //Responde GET sem parâmetro    
    [HttpGet]
    public IActionResult GetAll()
    {
        var produtos = _service.GetAll();
        return Ok(produtos);
    }

    // GET /api/produto
    //Responde GET com ID na URL  
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var produto = _service.GetById(id);
        if(produto == null)
            return NotFound();
        return Ok(produto);
    }

    //Responde a requisições POST
    [HttpPost]
    public IActionResult Create(
        [FromBody] Produto produto)
    {
        if(!ModelState.IsValid)

            //400 se inválido
            return BadRequest(ModelState);

        var criado = _service.Create(produto);

        //201 + URL do novo item
        return CreatedAtAction(
            nameof(GetById),
            new { id = criado.Id },
            criado);
    }

    //PUT /api/produto/1
    [HttpPut("{id}")]
    public IActionResult Update(
        int id,
        [FromBody] Produto produto)
    {
        var atualizado = _service.Update(id, produto);

        if(atualizado == null)
            return NotFound();

        return Ok(atualizado);
    }

    //DELETE /api/produto/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var deletado = _service.Delete(id);

        if(!deletado)
            return NotFound();

        return NoContent();
    }
    
}