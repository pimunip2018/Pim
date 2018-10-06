using System;

namespace HelpDesk.Domain.Entities
{
    public class Usuario
    {
        public int UsuarioID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime dtCadastro { get; set; }

        public DateTime dtNasc { get; set; }

        public bool Ativo { get; set; }
        public int PerfilId { get; set; }

        public virtual TipoPerfil TipoPerfil { get; set; }

        
        public bool UsuarioEspecial(Usuario usuario)
        {
            return usuario.Ativo && DateTime.Now.Year - usuario.dtNasc.Year >= 60;
        }
    }
}
