using AutoMapper;
using CaseItau.Application.Services;
using CaseItau.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CaseItau.API.Controllers
{
    [Route("api/[controller]")]
    public class TipoFundoController : ControllerBase
    {
        private readonly ITipoFundoService _tipoFundoService;
        private readonly IMapper _mapper;

        public TipoFundoController(ITipoFundoService tipoFundoService, IMapper mapper)
        {
            _tipoFundoService = tipoFundoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TipoFundoModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<TipoFundoModel>>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<TipoFundoModel>>(await _tipoFundoService.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
