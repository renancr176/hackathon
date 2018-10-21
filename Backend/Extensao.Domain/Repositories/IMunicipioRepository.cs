using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Queries;

namespace Extensao.Domain.Repositories
{
    public interface IMunicipioRepository
    {
        #region Select
        IEnumerable<MunicipioQuery> ObterMunicipiosPorUF(string uf);
        IEnumerable<MunicipioQuery> ObterTodosMunicipios();
        #endregion
    }
}
