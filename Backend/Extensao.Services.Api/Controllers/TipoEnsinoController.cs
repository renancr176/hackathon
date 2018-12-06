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
    public class TipoEnsinoController : BaseController
    {
        private readonly ITipoEnsinoRepository _tipoEnsinoRepository;
        
        public TipoEnsinoController(IUow uow, ITipoEnsinoRepository tipoEnsinoRepository) : base(uow)
        {
            _tipoEnsinoRepository = tipoEnsinoRepository;
        }

        /// <summary>
        ///  Retorna todos os estados
        /// </summary>
        /// <remarks>Retorna todos os estados</remarks>
        /// <returns>TipoEnsinoQuery</returns>
        [HttpGet]
        [Route("v1/tipo_ensino")]
        public IEnumerable<TipoEnsinoQuery> ObterTodosTiposEnsino() => _tipoEnsinoRepository.ObterTodosTiposEnsino();


    }
}

