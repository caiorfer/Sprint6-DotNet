using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApp.ClasseDeDados
{
    [Route("[controller]")]
    public class DadosController : Controller
    {
        private readonly ILogger<DadosController> _logger;

        public DadosController(ILogger<DadosController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost("prever-genero")]
        public ActionResult<ResultadoPredicao> PreverGenero([FromBody] Livro livro)
        {
            var predicao = predicaoEngine.Predict(livro);
            return Ok(predicao);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}