using Api_Exec_2.Context.Interface;
using Api_Exec_2.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Exec_2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        public IUnitOfWork<Contato> _unitOfWork;

        public ContatoController(IUnitOfWork<Contato> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contato>>> GetAllContatos()
        {
            return await _unitOfWork.RepositoryContato.GetAll();
        }

        [HttpGet("id", Name = "ObterContatoPorId")]
        public async Task<ActionResult<Contato>> GetContatoById(int id)
        {
            var contato = _unitOfWork.RepositoryContato.Get(c => c.Id == id);

            if (contato is null)
                return NotFound($"Não foi encontrado contato com o id {id}");

            return Ok(contato);
        }

        [HttpPost]
        public async Task<ActionResult<Contato>> Create(Contato contato)
        {
            var contatoCriado = await _unitOfWork.RepositoryContato.Create(contato);

            if (contatoCriado is null)
                return BadRequest("Erro ao criar o contato");

            _unitOfWork.CommitAsync();

            return contato;
        }

        [HttpPut]
        public async Task<ActionResult<Contato>> UpdateContato(int id, Contato contato)
        {
            if (id != contato.Id)
                return BadRequest($"O id informado {id} é diferente do id do contato {contato.Id}");

            var contatoAtualizado = _unitOfWork.RepositoryContato.Update(contato);

            if (contatoAtualizado is null)
                return BadRequest("Não foi possível atualiar o contato");

            _unitOfWork.CommitAsync();

            return Ok(contatoAtualizado);
        }

        [HttpDelete]
        public async Task<ActionResult<Contato>> DeleteContato(int id)
        {
            var contatoExcluir = await _unitOfWork.RepositoryContato.Get(c => c.Id == id);

            if (contatoExcluir is null)
                return NotFound($"Contato com o id {id} não foi encontrado");

            _unitOfWork.RepositoryContato.Delete(contatoExcluir);

            _unitOfWork.CommitAsync();

            return Ok(contatoExcluir);
        }
    }
}