using AutoMapper;
using CaseItau.API.Shared.Dtos;
using CaseItau.API.Shared.Models;
using CaseItau.Application.Exceptions;
using CaseItau.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace CaseItau.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        private readonly IFundoService _fundoService;
        private readonly IMapper _mapper;

        public FundoController(IFundoService fundoService, IMapper mapper)
        {
            _fundoService = fundoService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FundoModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<IEnumerable<FundoModel>>> Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<FundoModel>>(await _fundoService.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{codigo}")]
        [ProducesResponseType(typeof(FundoModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<FundoModel>> Get([FromRoute] string codigo)
        {
            try
            {
                return Ok(_mapper.Map<FundoModel>(await _fundoService.GetByIdAsync(codigo)));
            }
            catch (NotFoundException ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Post([FromBody] FundoModel model)
        {
            try
            {
                await _fundoService.PostAsync(_mapper.Map<FundoDto>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{codigo}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Put([FromRoute] string codigo, [FromBody] FundoModel model)
        {
            try
            {
                await _fundoService.PutAsync(codigo, _mapper.Map<FundoDto>(model));
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("{codigo}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> Delete([FromRoute] string codigo)
        {
            try
            {
                await _fundoService.DeleteAsync(codigo);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{codigo}/patrimonio")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> MovimentarPatrimonio([FromRoute] string codigo, [FromBody] decimal valorPatrimonio)
        {
            try
            {
                await _fundoService.MovimentarPatrimonioAsync(codigo, valorPatrimonio);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return Problem(ex.Message, statusCode: (int)HttpStatusCode.NotFound);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
