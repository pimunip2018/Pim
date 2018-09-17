using System.Collections.Generic;
using System.Linq;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Interfaces;

namespace HelpDesk.Infra.Data.Repositories
{
    public class TipoPerfilRepository : RepositoryBase<TipoPerfil>, ITipoPerfilRepository
    {
        public IEnumerable<TipoPerfil> BuscaPorNome(string nome)
        {
            return Db.TipoPerfis.Where(p => p.Descricao == nome);
        }
    }
}
