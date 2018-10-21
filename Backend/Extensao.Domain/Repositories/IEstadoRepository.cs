using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Queries;

namespace Extensao.Domain.Repositories
{
    public interface IEstadoRepository
    {
        #region Select
        IEnumerable<EstadoQuery> ObterTodosEstados();
        #endregion
    }
}
