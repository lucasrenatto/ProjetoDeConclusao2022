using Microsoft.Ajax.Utilities;
using System;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Web.Mvc;
using TCC.Domain.Model;
using TCC.Service;

namespace DesignFirstApproachCrud.Controllers
{
    public class ReclamacoesController : Controller
    {
        private readonly ReclamacoesService _reclamacoesService;
        public ReclamacoesController()
        {
            _reclamacoesService = new ReclamacoesService();
        }
        public async Task<ActionResult> Aberto()
        {
            var reclamacoes = await _reclamacoesService.BuscarTodasAtivas();
            ViewBag.reclamacoes = reclamacoes;
            return View();
        }
        public async Task ConcluirReclamacao(int id)
        {
            try
            {
                await _reclamacoesService.ConcluirReclamacao(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //        public async Task<JsonResult> VerDados(int id)
        //        {
        //            try
        //            {
        //                var reclamacoes = await _reclamacoesService.BuscarTodasAtivas();
        //                ViewBag.reclamacoes = reclamacoes;
        //                return (new ResultModel()


        //                },
        //                JsonRequestBehavior.AllowGet);

        //        }
        //            catch (Exception ex)
        //{

        //    throw;
        //}
        //}

        public async Task<ActionResult> Fechado()
        {
            var reclamacoes = await _reclamacoesService.BuscarTodasConcluidas();
            ViewBag.reclamacoes = reclamacoes;
            return View();
        }
    }
}