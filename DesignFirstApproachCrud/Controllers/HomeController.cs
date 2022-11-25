using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TCC.Domain.DTO;
using TCC.Service;

namespace DesignFirstApproachCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReclamacoesService _reclamacoesService;
        public HomeController()
        {
            _reclamacoesService = new ReclamacoesService();
        }
        public async Task<ActionResult> Index()
        {
            var reclamacoes = await _reclamacoesService.BuscarTodas();
            var quantidadeSAE = await _reclamacoesService.BuscarSAE();
            var quantidadeCFPL= await _reclamacoesService.BuscarCFPL();
            var quantidadeSaude = await _reclamacoesService.BuscarSaude();
            var quantidadeOutros = await _reclamacoesService.BuscarOutros();
            ViewBag.reclamacoes = reclamacoes.OrderByDescending(x => x.DataHora).ToList();
            ViewBag.quantidadeSAE = quantidadeSAE;
            ViewBag.quantidadeCFPL = quantidadeCFPL;
            ViewBag.quantidadeSaude = quantidadeSaude;
            ViewBag.quantidadeOutros = quantidadeOutros;
            return View();
        }

    }
}