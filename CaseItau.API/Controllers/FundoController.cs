using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Net;
using System.Threading.Tasks;
using CaseItau.API.Application.Exceptions;
using CaseItau.API.Application.Services;
using CaseItau.API.Application.Services.Model;
using Microsoft.AspNetCore.Mvc;

namespace CaseItau.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundoController : ControllerBase
    {
        private readonly IFundoService _fundoService;

        public FundoController(IFundoService fundoService)
        {
            _fundoService = fundoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FundoModel>>> Get()
        {
            try
            {
                return Ok(await _fundoService.GetAllAsync());
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<FundoModel>> Get(string codigo)
        {
            try
            {
                var fundo = await _fundoService.GetAsync(codigo);

                if (fundo is null)
                {
                    return NotFound(fundo);
                }

                return Ok(fundo);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FundoModel model)
        {
            try
            {
                await _fundoService.PostAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> Put([FromBody] FundoModel model)
        {
            try
            {
                await _fundoService.PutAsync(model);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }          
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> Delete(string codigo)
        {
            try
            {
                await _fundoService.DeleteAsync(codigo);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message, statusCode: (int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("{codigo}/patrimonio")]
        public void MovimentarPatrimonio(string codigo, [FromBody] decimal valorPatrimonio)
        {
            var con = new SQLiteConnection("Data Source=dbCaseItau.s3db");
            con.Open();
            var cmd = con.CreateCommand();
            cmd.CommandText = "UPDATE FUNDO SET PATRIMONIO = IFNULL(PATRIMONIO,0) + " + valorPatrimonio.ToString() + " WHERE CODIGO = '" + codigo + "'";
            cmd.CommandType = System.Data.CommandType.Text;
            var resultado = cmd.ExecuteNonQuery();
        }
    }
}
