using System.Data.SqlTypes;
using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.DTO_s;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilme([FromBody] CreateFilmeDTO filmeDTO)
    {

        Filme filme = _mapper.Map<Filme>(filmeDTO);

        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id }, filme);
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> RecuperaFilmes(
        [FromQuery] int skip = 0,
        [FromQuery] int take = 50,
        [FromQuery] string? nomeCinema = null)
    {
        if (nomeCinema == null)
        {
            return _mapper.Map<List<ReadFilmeDTO>>
                (_context.Filmes.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadFilmeDTO>>
                (_context.Filmes.Skip(skip).Take(take).Where(filme => 
                filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema)).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaFilmePorId(int id)
    {
        var filme = _context.Filmes
            .FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDTO = _mapper.Map<ReadFilmeDTO>(filme);
        return Ok(filmeDTO);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDTO filmeDTO)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if (filme == null)
        {
            return NotFound();
        }

        _mapper.Map(filmeDTO, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch)
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id) 
    {
        var filme = _context.Filmes.FirstOrDefault(
            filme => filme.Id == id);
        if (filme == null) return NotFound();

        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
