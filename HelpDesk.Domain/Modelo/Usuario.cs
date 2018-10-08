using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Modelo
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public bool Bloqueado { get; set; }
        public int Tentativa { get; set; }
        public string Senha { get; set; }
        public int PessoaPFId { get; set; }
        public string Sexo { get; set; }
        public PessoaPF PessoaPF { get; set; }
        public int TipoUsuarioId { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
