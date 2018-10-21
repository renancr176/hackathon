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
        [Route("v1/ranking_escolas/{ano:int}/{uf}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoUf(int ano, string uf) => _rankingEscolaController.ConsultarAnoUf(ano, uf);

        /// <summary>
        ///  Retorna ano e estado e municipio
        /// </summary>
        /// <remarks>Retorna ano e estado e municipio</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{uf}/{codigoMunicipio:int}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoUfMunicipio(int ano, string uf, int codigoMunicipio) => _rankingEscolaController.ConsultarAnoUfMunicipio(ano, uf, codigoMunicipio);

        /// <summary>
        ///  Retorna ano e estado e municipio e inclusao
        /// </summary>
        /// <remarks>Retorna ano e estado e municipio e inclusao</remarks>
        /// <returns>RankingEscolaQuery</returns>
        [HttpGet]
        [Route("v1/ranking_escolas/{ano:int}/{uf}/{codigoMunicipio:int}/{inclusao:bool}")]
        public IEnumerable<RankingEscolaQuery> ConsultarAnoUfMunicipioInclusao(int ano, string uf, int codigoMunicipio, bool inclusao) => _rankingEscolaController.ConsultarAnoUfMunicipioInclusao(ano, uf, codigoMunicipio, inclusao);


    }
}
