using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiExecUm.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        public readonly IUnitOfWork<Contato> _unitOfWork;
        public ContatoController(IUnitOfWork<Contato> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult<List<Contato>> Get()
        {
            return Ok(_unitOfWork.RepositoryContato?.GetAll());
        }

        [HttpGet("{cpf}", Name = "ObterContaPorCpf")]
        public ActionResult<Contato> Get(string cpf)
        {
            var contato = _unitOfWork.RepositoryContato.GetByCPF(c => c.CPF == cpf);
            if (contato is null)
                return NotFound($"Não encontrato contato para o CPF {cpf}");

            return Ok(contato);
        }

        [HttpPost]
        public ActionResult Post(Contato contato)
        {
            var novoContato = _unitOfWork.RepositoryContato.Create(contato);
            _unitOfWork.Commit();

            if (novoContato is null)
                return BadRequest("Erro ao criar contato");

            return Ok(novoContato);
        }

        [HttpPut]
        public ActionResult Put(int id, Contato contato)
        {
            if (id != contato.Id)
                return BadRequest($"ID {id} diferente do id do Contato {contato.Id} não foi possível atualizar");

            var contatoAtualizado = _unitOfWork.RepositoryContato.Update(contato);
            _unitOfWork.Commit();

            if (contatoAtualizado is null)
                return BadRequest("Erro ao atualizar o contato");

            return Ok(contatoAtualizado);
        }

        [HttpDelete]
        public ActionResult Delete(Contato contato)
        {
            if (contato is null) return BadRequest("Contato não pode ser nulo");

            var removerContato = _unitOfWork.RepositoryContato.Get(c => c.Id == contato.Id);
            _unitOfWork.Commit();

            if (removerContato is null)
                return BadRequest("Contato não encontrado");

            return Ok(removerContato);
        }
    }
}
