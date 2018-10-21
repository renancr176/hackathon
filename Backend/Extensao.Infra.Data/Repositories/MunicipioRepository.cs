using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Extensao.Domain.Queries;
using Extensao.Domain.Repositories;
using Extensao.Infra.Data.DataContexts;
using Extensao.Infra.Data.Transactions;

namespace Extensao.Infra.Data.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;

        public MunicipioRepository(DataContext context, IUow uow)
        {
            _context = context;
            _uow = uow;
        }

        public IEnumerable<MunicipioQuery> ObterMunicipiosPorUF(string uf)
        {
            return _context
                .Connection
                .Query<MunicipioQuery>(
                    "dbo.spGetMunicipios",
                    new
                    {
                        UF = uf
                    },
                    commandType: CommandType.StoredProcedure);
        }

        public IEnumerable<MunicipioQuery> ObterTodosMunicipios()
        {
            return _context
                .Connection
                .Query<MunicipioQuery>(
                    "dbo.spGetEstado",

                    commandType: CommandType.StoredProcedure);
        }
    }
}
