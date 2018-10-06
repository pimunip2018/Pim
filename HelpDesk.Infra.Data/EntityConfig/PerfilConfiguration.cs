using HelpDesk.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace HelpDesk.Infra.Data.EntityConfig
{
    public class PerfilConfiguration: EntityTypeConfiguration<TipoPerfil>
    {
		public PerfilConfiguration()
        {
            HasKey(p => p.PerfilId);
            Property(p => p.Descricao)
                .IsRequired();

           
        }
    }
}
