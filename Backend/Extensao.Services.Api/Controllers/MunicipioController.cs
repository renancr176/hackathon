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
    public class MunicipioController : BaseController
    {
        private readonly IMunicipioRepository _municipioRepository;


        public MunicipioController(IUow uow, IMunicipioRepository municipioRepository) : base(uow)
        {
            _municipioRepository = municipioRepository;
        }

        /// <summary>
        ///  Retorna todos os municipios por estado
        /// </summary>
        /// <remarks>Retorna todos os municipios por estado</remarks>
        /// <param name="uf">UF</param>
        /// <returns>MunicipioQuery</returns>
        [HttpGet]
        [Route("v1/municipio/{uf}")]
        public IEnumerable<MunicipioQuery> ObterMunicipiosPorUF(string uf) => _municipioRepository.ObterMunicipiosPorUF(uf);

        /// <summary>
        ///  Retorna todos os municipios
        /// </summary>
        /// <remarks>Retorna todos os municipios</remarks>        
        /// <returns>MunicipioQuery</returns>
        [HttpGet]
        [Route("v1/municipio")]
        public IEnumerable<MunicipioQuery> ObterTodosMunicipios() => _municipioRepository.ObterTodosMunicipios();
    }
}
