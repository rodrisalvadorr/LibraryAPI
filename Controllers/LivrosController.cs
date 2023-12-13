using Microsoft.AspNetCore.Mvc; // método da controller
using System.Collections.Generic; // lista
using LibraryAPI.Models;
using System.Linq;
using LibraryAPI.Data; // operações em lista
using Microsoft.EntityFrameworkCore; // ORM do banco de dados

namespace LibraryAPI.Controllers
{
  [ApiController]
  [Route("[Controller]")]
  public class LivrosController : ControllerBase
  {
    private readonly DataContext _context;

    public LivrosController(DataContext context)
    {
      _context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        List<Livro> lista = await _context.TB_LIVROS.ToListAsync();
        return Ok(lista);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
      try
      {
        Livro livro = await _context.TB_LIVROS.FirstOrDefaultAsync(busca => busca.Id == id);

        return Ok(livro);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Add(Livro novoLivro)
    {
      try
      {
        if (novoLivro.SerieId != null)
        {
          Serie serie = await _context.TB_SERIES.FirstOrDefaultAsync(busca => busca.Id == novoLivro.SerieId);
          
          if(serie == null)
          {
            throw new System.Exception("Não há uma série com este id");
          }
        }
        
        await _context.TB_LIVROS.AddAsync(novoLivro);
        await _context.SaveChangesAsync();

        return Ok(novoLivro.Id);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Livro livroEditado)
    {
      try
      {
        if (livroEditado.SerieId != null)
        {
          Serie serie = await _context.TB_SERIES.FirstOrDefaultAsync(busca => busca.Id == livroEditado.SerieId);
          
          if(serie == null)
          {
            throw new System.Exception("Não há uma série com este id");
          }
        }

        _context.TB_LIVROS.Update(livroEditado);
        int linhasAfetadas = await _context.SaveChangesAsync();

        return Ok(linhasAfetadas);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      try
      {
        Livro livro = await _context.TB_LIVROS.FirstOrDefaultAsync(busca => busca.Id == id);
        
        _context.TB_LIVROS.Remove(livro);
        int linhasAfetadas = await _context.SaveChangesAsync();

        return Ok(linhasAfetadas);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}