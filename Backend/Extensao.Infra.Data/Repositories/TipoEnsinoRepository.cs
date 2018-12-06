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
    public class TipoEnsinoRepository : ITipoEnsinoRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;

        public TipoEnsinoRepository(DataContext context, IUow uow)
        {
            _context = context;
            _uow = uow;
        }
        
        public IEnumerable<TipoEnsinoQuery> ObterTodosTiposEnsino()
        {
            return _context
                .Connection
                .Query<TipoEnsinoQuery>(
                    "dbo.spGetTipoEnsino",
                    commandType: CommandType.StoredProcedure);
        }
    }
}
