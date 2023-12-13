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
  public class SeriesController : ControllerBase
  {
    private readonly DataContext _context;

    public SeriesController(DataContext context)
    {
      _context = context;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
      try
      {
        List<Serie> lista = await _context.TB_SERIES.ToListAsync();
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
        Serie serie = await _context.TB_SERIES.FirstOrDefaultAsync(busca => busca.Id == id);

        return Ok(serie);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPost]
    public async Task<IActionResult> Add(Serie novaSerie)
    {
      try
      {
        await _context.TB_SERIES.AddAsync(novaSerie);
        await _context.SaveChangesAsync();

        return Ok(novaSerie.Id);
      }
      catch (System.Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpPut]
    public async Task<IActionResult> Update(Serie serieEditada)
    {
      try
      {
        _context.TB_SERIES.Update(serieEditada);
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
        Serie serie = await _context.TB_SERIES.FirstOrDefaultAsync(busca => busca.Id == id);

        if(serie == null)
        {
          throw new System.Exception("Não há uma serie com este id");
        }
        
        _context.TB_SERIES.Remove(serie);
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