using HelpDesk.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HelpDesk.MVC.Models.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage ="Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage ="Mínimo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Email")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage ="Digite um e-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Cadastro")]
        public DateTime dtCadastro { get; set; }

        [DisplayName("Data de Nascimento")]
        public DateTime dtNasc { get; set; }

        public bool Ativo { get; set; }
        public int PerfilId { get; set; }

        public virtual TipoPerfilViewModel TipoPerfil { get; set; }

        
    }
}