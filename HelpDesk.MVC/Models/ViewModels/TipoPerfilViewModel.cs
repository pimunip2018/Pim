using HelpDesk.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Domain.Entities
{
    public class TipoPerfilViewModel
    {
        [Key]
        public int PerfilId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        public string Descricao { get; set; }

        public int Ativo { get; set; }
        public int UsuarioId { get; set; }
        public virtual IEnumerable<UsuarioViewModel> Usuario { get; set; }
    }
}
