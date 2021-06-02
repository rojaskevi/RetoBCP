using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetoBCP.Models;
using RetoBCP.Services;

namespace RetoBCP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        public TipoCambioService _tipoCambioService;
        public UsuarioService _usuarioService;
        public TipoCambioController(TipoCambioService tipoCambioService,UsuarioService usuarioService) {
            _tipoCambioService = tipoCambioService;
            _usuarioService = usuarioService;
        }
        [HttpGet]
        public ActionResult<List<TipoCambio>> Get() {
            return _tipoCambioService.Get();
        }

        [HttpGet("{id}")]
        public CambioMoneda CambioMoneda(string monedaOrigen,string monedaDestino, decimal monto)
        {
            return _tipoCambioService.CambioMoneda(monedaOrigen, monedaDestino, monto);
        }


        [HttpPost("{id}")]
        public ActionResult<TipoCambio> Create(TipoCambio tipoCambio,string token)
        {
            try
            {
                Usuario usu = (Usuario)_usuarioService.ValidarToken(token);
                TipoCambio resp = (TipoCambio)_tipoCambioService.Create(tipoCambio);
                return Ok(resp);
            }
            catch (Exception ex)
            {
                TipoCambio error = new TipoCambio();
                error.MonedaDestino = "error token no existe";
                error.MonedaOrigen = "error token no existe";
                error.Cambio = 0;
                return error;
            }
            
        }

        [HttpPut]
        public ActionResult Update(TipoCambio tipoCambio) {
            _tipoCambioService.Update(tipoCambio.Id, tipoCambio);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id) {
            _tipoCambioService.Delete(id);
            return Ok();
        }




    }
}
