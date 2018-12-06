using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Queries;

namespace Extensao.Domain.Repositories
{
    public interface IRankingEscolaRepository
    {
        #region Select
        IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUf(int ano, int codigoTipoEnsino, string uf);
        IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipio(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio);
        IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfInclusao(int ano, int codigoTipoEnsino, string uf, bool inclusao);
        IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipioInclusao(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio, bool inclusao);
        #endregion
    }
}
