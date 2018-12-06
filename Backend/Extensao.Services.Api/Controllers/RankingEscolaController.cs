using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Extensao.Domain.Queries;
using Extensao.Domain.Repositories;
using Extensao.Infra.Data.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Extensao.Services.Api.Controllers
{
    public class RankingEscolaController : BaseController
    {
        private readonly IRankingEscolaRepository _rankingEscolaController;


        public RankingEscolaController(IUow uow, IRankingEscolaRepository rankingEscolaRepository) : base(uow)
        {
            _rankingEscolaController = rankingEscolaRepository;
        }

        /// <summary>
        ///  Retorna ano e estado
        /// </summary>
        /// <remarks>Retorna ano e estado</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{codigoTipoEnsino:int}/{uf}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUf(int ano, int codigoTipoEnsino, string uf) => _rankingEscolaController.ConsultarAnoTipoEnsinoUf(ano, codigoTipoEnsino, uf);

        /// <summary>
        ///  Retorna ano e estado e municipio
        /// </summary>
        /// <remarks>Retorna ano e estado e municipio</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{codigoTipoEnsino:int}/{uf}/{codigoMunicipio:int}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipio(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio) => _rankingEscolaController.ConsultarAnoTipoEnsinoUfMunicipio(ano, codigoTipoEnsino, uf, codigoMunicipio);

        /// <summary>
        ///  Retorna ano e estado e municipio
        /// </summary>
        /// <remarks>Retorna ano e estado e municipio</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{codigoTipoEnsino:int}/{uf}/{inclusao:bool}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfInclusao(int ano, int codigoTipoEnsino, string uf, bool inclusao) => _rankingEscolaController.ConsultarAnoTipoEnsinoUfInclusao(ano, codigoTipoEnsino, uf, inclusao);

        /// <summary>
        ///  Retorna ano e estado e municipio e inclusao
        /// </summary>
        /// <remarks>Retorna ano e estado e municipio e inclusao</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{codigoTipoEnsino:int}/{uf}/{codigoMunicipio:int}/{inclusao:bool}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipioInclusao(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio, bool inclusao) => _rankingEscolaController.ConsultarAnoTipoEnsinoUfMunicipioInclusao(ano, codigoTipoEnsino, uf, codigoMunicipio, inclusao);


    }
}
