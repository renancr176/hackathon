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
    public class EstadoController : BaseController
    {
        private readonly IEstadoRepository _estadoRepositoryRepository;


        public EstadoController(IUow uow, IEstadoRepository estadoRepository) : base(uow)
        {
            _estadoRepositoryRepository = estadoRepository;
        }

        /// <summary>
        ///  Retorna todos os estados
        /// </summary>
        /// <remarks>Retorna todos os estados</remarks>
        /// <returns>MunicipioQuery</returns>
        [HttpGet]
        [Route("v1/estado")]
        public IEnumerable<EstadoQuery> ObterTodosEstados() => _estadoRepositoryRepository.ObterTodosEstados();

        
    }
}
