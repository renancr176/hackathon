using System;
using System.Collections.Generic;
using System.Text;
using Extensao.Domain.Queries;

namespace Extensao.Domain.Repositories
{
    public interface IRankingEscolaRepository
    {
        #region Select
        IEnumerable<RankingEscolaQuery> ConsultarAnoUf(int ano, string uf);
        IEnumerable<RankingEscolaQuery> ConsultarAnoUfMunicipio(int ano, string uf, int codigomunicipio);
        IEnumerable<RankingEscolaQuery> ConsultarAnoUfMunicipioInclusao(int ano, string uf, int codigoMunicipio, bool inclusao);
        #endregion
    }
}
