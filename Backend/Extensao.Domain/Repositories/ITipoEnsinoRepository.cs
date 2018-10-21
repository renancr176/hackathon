using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Queries;

namespace Extensao.Domain.Repositories
{
    public interface ITipoEnsinoRepository
    {
        #region Select
        IEnumerable<TipoEnsinoQuery> ObterTodosTiposEnsino();
        #endregion
    }
}
