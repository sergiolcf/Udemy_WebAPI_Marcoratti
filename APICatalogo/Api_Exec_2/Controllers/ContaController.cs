using Api_Exec_2.Context.Interface;
using Api_Exec_2.Model;
using Microsoft.AspNetCore.Mvc;

namespace Api_Exec_2.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class ContaController : Controller
    {
        public IUnitOfWork<Conta> _unitOfWork;

        public ContaController(IUnitOfWork<Conta> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<List<Conta>>> GetList()
        {
            return await _unitOfWork.RepositoryConta.GetAll();
        }

        [HttpGet("id", Name = "Obtem por ID")]
        public async Task<ActionResult<Conta>> GetContaById(int id)
        {
            var conta = await _unitOfWork.RepositoryConta.Get(c => c.Id == id);
            if (conta is null)
                return NotFound($"Conta com o id {id}, não foi encontrada.");

            _unitOfWork.CommitAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Conta>> Create(Conta conta)
        {
            if (conta is null)
                return BadRequest("Conta não pode ser nula");

            await _unitOfWork.RepositoryConta.Create(conta);
            _unitOfWork.CommitAsync();

            return Ok(conta);
        }

        [HttpPut]
        public async Task<ActionResult<Conta>> Update(int id, Conta conta)
        {
            if (id != conta.Id)
                return BadRequest($"O id informado {id}, esta diferente do id da conta {conta.Id}");

            var contaAtualizar = await _unitOfWork.RepositoryConta.Get(c => c.Id == id);

            if (contaAtualizar is null)
                return NotFound($"Não foi encontrado conta com o id{id}");

            _unitOfWork.CommitAsync();
            return Ok(contaAtualizar);
        }

        [HttpDelete]
        public async Task<ActionResult<Conta>> Delete(int id, Conta conta)
        {
            var contaExcluir = _unitOfWork.RepositoryConta.Get(c => c.Id == id);

            if (contaExcluir is null)
                return NotFound($"Não foi encontrado conta com o id {id}");

            _unitOfWork.CommitAsync();
            return Ok(contaExcluir);
        }
    }
}