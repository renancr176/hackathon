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
    public class EstadoRepository : IEstadoRepository
    {
        private readonly DataContext _context;
        private readonly IUow _uow;

        public EstadoRepository(DataContext context, IUow uow)
        {
            _context = context;
            _uow = uow;
        }


        public IEnumerable<EstadoQuery> ObterTodosEstados()
        {
            return _context
                .Connection
                .Query<EstadoQuery>(
                    "dbo.spGetEstado",

                    commandType: CommandType.StoredProcedure);
        }
    }
}
