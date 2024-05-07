using ApiExecUm.Model;
using ApiExecUm.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ApiExecUm.Controllers
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

        public ActionResult<List<Conta>> Get()
        {
            return Ok(_unitOfWork.RepositoryConta.GetAll());
        }

        [HttpGet("{cnpj}", Name = "ObterContaPorCnpj")]
        public ActionResult<Conta> Get(string cnpj)
        {
            var conta = _unitOfWork.RepositoryConta.GetByCNPJ(c => c.CNPJ == cnpj);

            if (conta is null)
                return NotFound("Não existe conta com este CNPJ");

            return Ok(conta);
        }

        [HttpPost]
        public ActionResult Post(Conta conta)
        {
            var contaNova = _unitOfWork.RepositoryConta.Create(conta);
            _unitOfWork.Commit();

            if (contaNova is null)
                return BadRequest("Não foi possível criar a conta");


            return Ok(contaNova);
        }


        [HttpPut]
        public ActionResult Put(int id, Conta conta)
        {

            if (conta is null)
                return BadRequest("Conta não pode ser nulo");

            if (id != conta.Id)
                return BadRequest($"O id {id} informado é diferente do id da conta {conta.Id}");

            _unitOfWork.RepositoryConta.Update(conta);
            _unitOfWork.Commit();

            return Ok(conta);
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var contaExcluir = _unitOfWork.RepositoryConta.Get(c => c.Id == id);

            if (contaExcluir is null)
                return BadRequest("Conta não existe");

            _unitOfWork.RepositoryConta.Delete(contaExcluir);
            _unitOfWork.Commit();

            return Ok(contaExcluir);
        }
    }
}
