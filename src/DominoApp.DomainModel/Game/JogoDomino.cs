using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.DomainModel.Game
{
    public class JogoDomino
    {
        /// <summary>
        /// Id único do jogo entre todas as partidas online
        /// </summary>
        public string Id { get; set; }

        public Mesa Mesa { get; set; }

        public List<Jogador> Jogadores { get; set; }

        private JogoDomino()
        {
        }

        /// <summary>
        /// Inicializa uma nova partida
        /// </summary>
        /// <param name="jogadores"></param>
        /// <returns></returns>
        public static JogoDomino NovoJogo(params string[] jogadores)
        {
            var jogo = new JogoDomino();
            jogo.Mesa = new Mesa();
            jogo.Jogadores = new List<Jogador>();

            foreach (var idJogador in jogadores)
            {
                var jogador = new Jogador(idJogador) { Mao = jogo.Mesa.ComprarMao() };
                jogo.Jogadores.Add(jogador);
            }

            var sha256 = System.Security.Cryptography.SHA256.Create();
            var seed = new Random().Next() + string.Concat(jogadores);

            jogo.Id = Convert.ToBase64String(sha256.ComputeHash(Encoding.ASCII.GetBytes(seed)));

            return jogo;
        }

        /// <summary>
        /// Executa uma jogada com o que recebeu do cliente
        /// </summary>
        /// <param name="idJogador">nome de usuário</param>
        /// <param name="pedra">qual é a pedra NxN</param>
        /// <param name="lado">'e'squerdo ou 'd'ireito</param>
        public StatusJogo Jogar(string idJogador, string pedra, string lado)
        {
            var jogador = Jogadores.First(j => j.Id == idJogador);
            jogador.Jogar(pedra);
            var eLado = lado == "e" ? Mesa.Lado.Esquerdo : Mesa.Lado.Direito;
            Mesa.Jogar(Pedra.FromString(pedra), eLado);

            var oponente = Jogadores.First(j => j.Id != idJogador);

            return new StatusJogo()
            {
                Id = this.Id,
                Mao = jogador.Mao,
                Mesa = Mesa.PedrasJogadas.ToList(),
                PontaEsquerda = Mesa.PontaEsquerda,
                PontaDireita = Mesa.PontaDireita,
                TotalPedrasMonte = Mesa.Monte.Count,
                TotalPedrasOponente = oponente.Mao.Count
            };
        }

        public void ComprarPedra(string idJogador)
        {
            var jogador = Jogadores.First(j => j.Id == idJogador);
            jogador.Adicionar(Mesa.ComprarPedra());
        }

        /// <summary>
        /// Estrutura com estado do jogo devolvido para o player que executou um movimento
        /// </summary>
        public struct StatusJogo
        {
            public string Id;
            public List<Pedra> Mao;
            public List<Pedra> Mesa;
            public int PontaEsquerda;
            public int PontaDireita;
            public int TotalPedrasMonte;
            public int TotalPedrasOponente;
        }
    }
}
