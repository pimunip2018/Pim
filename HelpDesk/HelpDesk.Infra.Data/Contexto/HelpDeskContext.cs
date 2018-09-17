using HelpDesk.Domain.Entities;
using HelpDesk.Infra.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace HelpDesk.Infra.Data.Contexto
{
    public class HelpDeskContext : DbContext
    {
        public HelpDeskContext()
            : base("HelpDeskModeloDDD")
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<TipoPerfil> TipoPerfis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a Pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            //Tudo que tiver "id" vira chave primaria
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "id")
                .Configure(p => p.IsKey());

            //Quando for string a tabela fica varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Quando for string o maximo do campo fica 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfiguration());
            modelBuilder.Configurations.Add(new PerfilConfiguration());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(Entry => Entry.Entity.GetType().GetProperty("dtCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("dtCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("dtCadastro").IsModified = false;
                }
            }
            return base.SaveChanges();
        }

        // public System.Data.Entity.DbSet<HelpDesk.MVC.Models.ViewModels.UsuarioViewModel> UsuarioViewModels { get; set; }

        //public System.Data.Entity.DbSet<HelpDesk.Domain.Entities.TipoPerfilViewModel> TipoPerfilViewModels { get; set; }
    }
}
