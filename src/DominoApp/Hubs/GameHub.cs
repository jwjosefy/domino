using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DominoApp.Services;
using Microsoft.AspNet.SignalR;

namespace DominoApp.Hubs
{
    /// <summary>
    /// Controller principal para o motor de jogo
    /// </summary>
    public class GameHub : Hub
    {
        /// <summary>
        /// Método chamado pelo jogador para sinalizar que está disponível para jogar
        /// </summary>
        /// <param name="idJogador"></param>
        public void WaitStart(string idJogador)
        {
            DominoManager.Instance.AdicionarJogadorFilaEspera(idJogador, Context.ConnectionId);
        }

        public void Play(string payload)
        {
            Clients.All.hello();
        }


        public void Abandon(string payload)
        {
           
        }

        public override Task OnConnected()
        {

            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            /* TODO Criar controle para desconexão de jogador
             * Quando um jogador for desconectado da partida
             * stopCalled 
             *    false -> desconexão forçada (conexão do jogador caiu, máquina travou, etc)
             *    true -> jogador pediu a desconexão
             */
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            // TODO Criar controle para reconexão de jogador
            return base.OnReconnected();
        }
    }
}