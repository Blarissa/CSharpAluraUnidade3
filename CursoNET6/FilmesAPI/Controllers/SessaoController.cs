using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessaoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public SessaoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaSessao(CreateSessaoDto createSessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(createSessaoDto);
            
            _context.Sessoes.Add(sessao);
            _context.SaveChanges();
            
            return CreatedAtAction(nameof(RecuperaSessoesPorId), 
                new { filmeId = sessao.FilmeId, cinemaId = sessao.CinemaId }, 
                sessao);
        }

        [HttpGet]
        public IEnumerable<ReadSessaoDto> RecuperaSessoes()
        {
            return _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.ToList());
        }

        [HttpGet("{filmeId}/{cinemaId}")]
        private IActionResult RecuperaSessoesPorId(int filmeId, int cinemaId)
        {
            Sessao sessao = _context.Sessoes
                .FirstOrDefault(sessao => sessao.FilmeId == filmeId && 
                                sessao.CinemaId == cinemaId);

            if (sessao != null)
            {
                ReadSessaoDto sessaoDto = _mapper.Map<ReadSessaoDto>(sessao);

                return Ok(sessaoDto);
            }

            return NotFound();
        }
    }
}
