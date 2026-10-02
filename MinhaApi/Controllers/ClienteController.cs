using MinhaApi.Models;
using MinhaApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MinhaApi.Controllers;
//Habilita validações automáticas
[ApiController]

//URL base = api/produto

[Route("api/[controller]")]
public class ClienteController
    //Herda helpers HTTP
    :ControllerBase
{
    private readonly IClienteService _service;

    public ClienteController(
        //Injeção de dependência
        IClienteService service)
        => _service = service;
    
    // GET /api/produto
    //Responde GET sem parâmetro    
    [HttpGet]
    public IActionResult GetAll()
    {
        var clientes = _service.GetAll();
        return Ok(clientes);
    }

    // GET /api/produto
    //Responde GET com ID na URL  
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var cliente = _service.GetById(id);
        if(cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    //Responde a requisições POST
    [HttpPost]
    public IActionResult Create(
        [FromBody] Cliente cliente)
    {
        if(!ModelState.IsValid)

            //400 se inválido
            return BadRequest(ModelState);

        var criado = _service.Create(cliente);

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
        [FromBody] Cliente cliente)
    {
        var atualizado = _service.Update(id, cliente);

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