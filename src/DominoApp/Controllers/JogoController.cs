using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DominoApp.Hubs;
using DominoApp.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;

namespace DominoApp.Controllers
{
    public class JogoController : Controller
    {
        // GET: Jogo
        public ActionResult Index()
        {
            var domino = DominoManager.Instance;

            return View();
        }


        [HttpPost]
        public JsonResult IniciarPartidaComJogador(string oponente)
        {
            var jogador = HttpContext.User.Identity.GetUserId();
            var domino = DominoManager.Instance;
            string connIdOponente;

            if ((connIdOponente = domino.RemoverJogadorDaFila(oponente)) == null)
                return Json(new {status = "erro", msg = $"Oponente {oponente} não está online"});

            // jogador estava aguardando, inicia partida
            var hub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();

            var jogo = domino.CriarJogo(jogador, oponente);

            hub.Clients.Client(connIdOponente).OnStart(jogo.Id, jogador, oponente);
            return Json(new {status = "ok", id = jogo.Id});
        }

        [HttpPost]
        public JsonResult IniciarPartidaAnonima()
        {
            var jogador = HttpContext.User.Identity.GetUserId();
            var domino = DominoManager.Instance;
            Tuple<string, string> oponente;

            if ((oponente = domino.ProximoNaFila()) == null)
            {
                // ninguém na fila, coloca o próprio jogador na espera
                // devolve status wait no ajax para o cliente saber que deve chamar 
                // a fila via hub do SignalR
                return Json(new {status = "wait"});
            }

            // achou o próximo na fila, inicia o jogo
            var hub = GlobalHost.ConnectionManager.GetHubContext<GameHub>();

            var jogo = domino.CriarJogo(jogador, oponente.Item1);

            hub.Clients.Client(oponente.Item2).OnStart(jogo.Id, jogador, oponente);
            return Json(new { status = "ok", id = jogo.Id });
        }
    }
}