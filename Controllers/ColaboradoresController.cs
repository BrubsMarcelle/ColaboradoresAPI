using ColaboradoresAPI.Enums;
using ColaboradoresAPI.Model;
using ColaboradoresAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ColaboradoresAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ColaboradoresController : Controller
    {
        private readonly IColaboradorRepository _repository;
        public ColaboradoresController(IColaboradorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var colaboradores = await _repository.BuscarColaboradores();
            return Ok(colaboradores.OrderBy(x => x.id));
        }

        [HttpGet]
        [Route("/buscar/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var colaborador = await _repository.BuscarColaboradorPorId(id);
            return colaborador != null ? Ok(colaborador) : NotFound("Não encontrado");
        }

        [HttpGet]
        [Route("/buscarPorNome/{Nome}")]
        public async Task<IActionResult> GetByName(string Nome)
        {
            if (string.IsNullOrEmpty(Nome))
            {
                throw new ArgumentException($"'{nameof(Nome)}' não pode ser nulo ou vazio", nameof(Nome));
            }
            var colaborador = await _repository.BuscarColaboradorPorNome(Nome);

            return colaborador != null ? Ok(colaborador) : NotFound("Colaborador não encontrado");
        }

        [HttpPost]
        [Route("/cadastrar")]
        public async Task<IActionResult> Post(ColaboradoresModel colab)
        {
            _repository.AdicionarColaborador(colab);
            return await _repository.SaveChangesAsync()
                ? Ok("Colaborador Adicionado com sucesso") : BadRequest("Não foi possivel adicionar Colaboradores");
        }

        [HttpPut]
        [Route("/alterar/{id}")]
        public async Task<IActionResult> Put(int  id, ColaboradoresModel colab)
        {
            var colaboradorBanco = await _repository.BuscarColaboradorPorId(id);
            if (colaboradorBanco == null) return NotFound("Colaborador não encontrado");

            colaboradorBanco.NOME = colab.NOME ?? colaboradorBanco.NOME;
            colaboradorBanco.CPF = colab.CPF ?? colaboradorBanco.CPF;
            colaboradorBanco.EMAIL = colab.EMAIL ?? colaboradorBanco.EMAIL;
            colaboradorBanco.TELEFONE = colab.TELEFONE ?? colaboradorBanco.TELEFONE;
            colaboradorBanco.dataNascimento = colab.dataNascimento != new DateTime() ? colab.dataNascimento : colaboradorBanco.dataNascimento;
            colaboradorBanco.CARGO = colab.CARGO ?? colaboradorBanco.CARGO;
            colaboradorBanco.EMPRESA = colab.EMPRESA ?? colaboradorBanco.EMPRESA;
            colaboradorBanco.OBSERVACAO = colab.OBSERVACAO ?? colaboradorBanco.OBSERVACAO;
            colaboradorBanco.dataDesligamento = colab.dataDesligamento ?? colaboradorBanco.dataDesligamento;
            colaboradorBanco.dataAdmissao = colab.dataAdmissao != new DateTime() ? colab.dataAdmissao : colaboradorBanco.dataAdmissao;
            colaboradorBanco.SITUACAO = colab.SITUACAO != new Status() ? colab.SITUACAO : colaboradorBanco.SITUACAO;
            colaboradorBanco.CONTRATACAO = colab.CONTRATACAO != new Contratacao() ? colab.CONTRATACAO : colaboradorBanco.CONTRATACAO; 
            colaboradorBanco.gestorDireto = colab.gestorDireto ?? colaboradorBanco.gestorDireto;
            colaboradorBanco.ALURA = colab.ALURA != new Status() ? colab.ALURA : colaboradorBanco.ALURA;
            colaboradorBanco.SQUAD = colab.SQUAD ?? colaboradorBanco.SQUAD;

            _repository.AtualizarColaborador(colaboradorBanco);
            return await _repository.SaveChangesAsync()
                ? Ok("Colaborador atualizado")
                : BadRequest("Não atualizado");
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<IActionResult> Delte(int id)
        {
            var colaboradorBanco = await _repository.BuscarColaboradorPorId(id);
            if (colaboradorBanco == null) return NotFound("Colaborador não encontrado");

            _repository.DeletarColaborador(colaboradorBanco);

            return await _repository.SaveChangesAsync()
                ? Ok("Deletado com sucesso") : BadRequest("Não foi possivel deletar o colaborador");
        }

        public static string ObterStringSemAcentoECaracterEspeciais (string str)
        {
            string[] acentos = new string[] { };
            string[] semAcentos = new string[] { };

            for(int i = 0; i <acentos.Length; i++)
            {
                str = str.Replace(acentos[i], semAcentos[i]);
            }

            string[] caracterEspeciais = { };
            for (int i = 0; i <= caracterEspeciais.Length; i++)
            {
                str = str.Replace(caracterEspeciais[i], "");
            }

            str = Regex.Replace(str, @"[^\w\.@-]", "", RegexOptions.None, TimeSpan.FromSeconds(1.5));
            return str.Trim();
        }
    }
}
