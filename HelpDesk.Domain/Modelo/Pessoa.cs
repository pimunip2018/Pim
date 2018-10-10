using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Modelo
{
    public class Pessoa
    {
        public int CPF { get; set; }
        public int TipoPessoaId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public string Nome { get; set; }
        public DateTime DtNasc { get; set; }
        public string Telefone { get; set; }
        public int Ramal { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public int SexoId { get; set; }
        public Sexo Sexo { get; set; }
        public int EstadoCivilId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string RazaoSocial { get; set; }
        public int CNPJ { get; set; }
        public DateTime DtFundacao { get; set; }
        public string Cargo { get; set; }
        public Endereco Endereco { get; set; }
        
    }
}
