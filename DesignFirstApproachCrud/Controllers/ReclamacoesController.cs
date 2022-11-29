using Microsoft.Ajax.Utilities;
using System;
using System.Net;
using System.Net.Mail;
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
        public async Task<JsonResult> ConcluirReclamacao(int id)
        {
            try
            {
                await _reclamacoesService.ConcluirReclamacao(id);
                return Json(new
                {
                    Success = true,
                    Message = "Reclamação Concluída com Sucesso!"
                },
             JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(new
                {
                    Success = false,
                    Message = "Não foi possível concluír essa reclamação."
                },
                  JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> VerDados(int id)
        {
            try
            {
                var reclamacoes = await _reclamacoesService.BuscarPorID(id);
                return Json(new
                {
                    Success = true,
                    Object = reclamacoes,
                    Message = "Reclamação Buscada com Sucesso!"
                },
              JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = false,
                    Message = $"Não foi possível encontrar a reclamação"
                },
                 JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> Fechado()
        {
            var reclamacoes = await _reclamacoesService.BuscarTodasConcluidas();
            ViewBag.reclamacoes = reclamacoes;
            return View();
        }
        public async Task<JsonResult> EnviarEmails()
        {
            try
            {
                var reclamacoes = await _reclamacoesService.BuscarTodasAtivas();
                foreach (var reclamacao in reclamacoes)
                {

                    //cria uma mensagem
                    MailMessage mail = new MailMessage();

                    //define os endereços
                    mail.From = new MailAddress("lucas_renatto@unifio.edu.br");
                    mail.To.Add("lucasrenattotmz07@hotmail.com");

                    //define o conteúdo
                    mail.Subject = $"Existe um problema na rua: {reclamacao.Rua}";
                    mail.Body = $"Olá me chamo {reclamacao.NomeUsuario} e encontrei um problema na rua {reclamacao.Rua}" +
                        $"que é o seguinte : {reclamacao.Descricao} eu reportei esse erro usando o Reclame Ourinhos no dia {reclamacao.DataHora.ToString("dd/MM/yyyy")}" +
                        $" as {reclamacao.DataHora.ToString("HH:mm")} esse é um problema para {reclamacao.Area.Descricao} resolver, desde já agradeço!";

                    //envia a mensagem
                    using (var smtp = new SmtpClient("smtp.gmail.com"))
                    {
                        smtp.EnableSsl = true; // GMail requer SSL
                        smtp.Port = 587;       // porta para SSL
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // modo de envio
                        smtp.UseDefaultCredentials = false; // vamos utilizar credencias especificas

                        // seu usuário e senha para autenticação
                        smtp.Credentials = new NetworkCredential("lucas_renatto@unifio.edu.br", "1597532684sd");

                        // envia o e-mail
                        smtp.Send(mail);
                    }
                }
                return Json(new
                {
                    Success = true,
                    Message = "Reclamações Enviadas com Sucesso"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    Success = true,
                    Message = "Falha ao Enviar as Reclamações"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public async Task<JsonResult> AbertosFechados()
        {
            try
            {
                var reclamacoes = await _reclamacoesService.BuscarTodasAtivas();
                int reclamacoesC = reclamacoes.Count;
                var reclamacoesFechadas = await _reclamacoesService.BuscarTodasConcluidas();
                int reclamacoesF = reclamacoesFechadas.Count;
                return Json(new
                {
                    Success = true,
                    ReclamA = reclamacoesC,
                    ReclamF = reclamacoesF,
                    Message = "Reclamação Buscada com Sucesso!"
                },
           JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}