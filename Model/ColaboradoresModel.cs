using ColaboradoresAPI.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColaboradoresAPI.Model
{
    [Table("COLABORADORES")]
    public class ColaboradoresModel
    {
        public int id { get; set; }
        public string NOME { get; set; }
        public string CPF { get; set; }
        public DateTime dataNascimento { get; set; }
        public string EMAIL { get; set; }
        public string TELEFONE { get; set; }
        public Contratacao CONTRATACAO { get; set; }
        public string SQUAD { get; set; }
        public DateTime dataAdmissao { get; set; }
        public string dataDesligamento { get; set; }
        public Status  SITUACAO{ get; set; }
        public string CARGO { get; set; }
        public string EMPRESA { get; set; }
        public string gestorDireto { get; set; }
        public Status ALURA { get; set; }
        public string OBSERVACAO { get; set; }
    }
}
