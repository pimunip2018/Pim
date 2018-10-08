using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Modelo
{
    public class PessoaPF
    {
        public int PessoaPFId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DtNasc { get; set; }
        public string Telefone { get; set; }
        public string TelefoneCelular { get; set; }
        public string Email { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}
