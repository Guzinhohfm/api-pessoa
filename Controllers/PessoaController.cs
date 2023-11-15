using api_pessoa.Data.Dtos;
using api_pessoa.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace api_pessoa.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private AppDbContext _context;
        private IMapper _mapper;

        public PessoaController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PessoaController(AppDbContext context)
        {
            _context = context;
        }



        /// <summary>
        /// Adiciona uma pessoa e seus respectivos dados pessoais ao banco de dados
        /// </summary>
        /// <param name="pessoa">Objeto com os campos necessários para criação de uma pessoa</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AdicionarPessoa([FromBody] CreatePessoaDto pessoaDto)
        {
            Pessoa pessoa = _mapper.Map<Pessoa>(pessoaDto);
            _context.pessoas.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ListarPessoaPorId),
              new { id = pessoa.Id }
            , pessoa);
        }

        /// <summary>
        /// Retorna a lista de pessoas salvas
        /// </summary>
        ///
        /// <returns>IEnumerable</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Pessoa> ListarPessoas([FromQuery] int take = 10)
        {
            return _context.pessoas.Take(take);
        }

        /// <summary>
        /// Retorna uma pessoa especificada pelo id
        /// </summary>
        /// <param name="id">parâmetro necessário para localização da pessoa especificada e retorna-la</param>
        /// 
        ///
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a busca seja feita com sucesso</response>

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult ListarPessoaPorId(int id)
        {
            var pessoa = _context.pessoas.FirstOrDefault(pessoa => pessoa.Id == id);

            if (pessoa == null) return NotFound();
            return Ok(pessoa);
        }

        /// <summary>
        /// Remove uma pessoa especificada pelo id
        ///  </summary>
        /// <param name="id">parâmetro necessário para localização da pessoa especificada e executar o delete</param>
        ///
        ///
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a remoção seja feita com sucesso</response>

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public IActionResult RemoverPessoaPorId(int id)
        {

            var pessoa = _context.pessoas.FirstOrDefault(pessoa => pessoa.Id == id);

            if (pessoa == null)
            {
                return NotFound();

            }
            else
            {
                _context.pessoas.Remove(pessoa);
                _context.SaveChanges();
                return Ok(pessoa);
            }



        }

        /// <summary>
        /// Edita uma pessoa especificada pelo id e campo modificado
        ///  </summary>
        /// <param name="id">parâmetro necessário para localização da pessoa especificada e executar a edição</param>
        /// <param name="pessoa">Objeto necessário para identificar qual campo será alterado</param>
        ///
        /// <returns>IActionResult</returns>
        ///  /// <response code="200">Caso a edição seja feita com sucesso</response>

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult EditarPessoa(int id, [FromBody] Pessoa pessoa)
        {
            if (pessoa.Id == id)
            {
                _context.pessoas.Update(pessoa);
                _context.SaveChanges();
                return Ok("Os dados foram atualizados com sucesso");
            }
            else
            {
                return BadRequest("Não encontrado dados");
            }

        }


    }
}
