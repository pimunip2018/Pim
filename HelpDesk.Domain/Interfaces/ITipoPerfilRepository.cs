using HelpDesk.Domain.Entities;
using System.Collections.Generic;

namespace HelpDesk.Domain.Interfaces
{
    public interface ITipoPerfilRepository : IRepositoryBase<TipoPerfil>
    {
        IEnumerable<TipoPerfil> BuscaPorNome(string nome);
    }
}
