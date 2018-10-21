using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Extensao.Domain.Queries;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;
using Extensao.Domain.Repositories;

namespace Extensao.Infra.Data.Repositories
{
    public class RankingEscolaRepository : IRankingEscolaRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;

        public RankingEscolaRepository(DataContext context, IUow uow)
        {
            _context = context;
            _uow = uow;
        }

        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUf(int ano, int codigoTipoEnsino, string uf)
        {
            return _context
                .Connection
                .Query<RankingEscolaQuery>(
                    "dbo.spGetRankingEscolas",
                    new
                    {
                        Ano = ano,
                        CodigoTipoEnsino = codigoTipoEnsino,
                        UF = uf
                    },
                    commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipio(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio)
        {
            return _context
                .Connection
                .Query<RankingEscolaQuery>(
                    "dbo.spGetRankingEscolas",
                    new
                    {
                        Ano = ano,
                        UF = uf,
                        CodigoTipoEnsino = codigoTipoEnsino,
                        CodigoMunicipio = codigoMunicipio
                    },

                    commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfInclusao(int ano, int codigoTipoEnsino, string uf, bool inclusao)
        {
            return _context
                .Connection
                .Query<RankingEscolaQuery>(
                    "dbo.spGetRankingEscolas",
                    new
                    {
                        Ano = ano,
                        UF = uf,
                        CodigoTipoEnsino = codigoTipoEnsino,
                        TemNee = inclusao
                    },

                    commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<RankingEscolaQuery> ConsultarAnoTipoEnsinoUfMunicipioInclusao(int ano, int codigoTipoEnsino, string uf, int codigoMunicipio, bool inclusao)
        {
            return _context
                .Connection
                .Query<RankingEscolaQuery>(
                    "dbo.spGetRankingEscolas",
                    new
                    {
                        Ano = ano,
                        CodigoTipoEnsino = codigoTipoEnsino,
                        UF = uf,
                        CodigoMunicipio = codigoMunicipio,
                        TemNee = inclusao
                    },

                    commandType: CommandType.StoredProcedure);
        }
    }
}
