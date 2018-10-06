using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Domain.Entities
{
    public class TipoPerfil
    {
        public int PerfilId { get; set; }
        public string Descricao { get; set; }
        public int Ativo { get; set; }
        public int UsuarioId { get; set; }
        public virtual IEquatable<Usuario> Usuario { get; set; }

    }
}
