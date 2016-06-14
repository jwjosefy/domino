using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominoApp.DomainModel.Game;

namespace DominoApp.Services
{
    /// <summary>
    /// Regras de negócio para controlar o estado dos jogos e a fila de espera
    /// </summary>
    public class DominoManager
    {
        #region Singleton

        static DominoManager _instance;
        public static DominoManager Instance => _instance = _instance ?? new DominoManager();

        #endregion
        
        /// <summary>
        /// Jogos online simultâneos
        /// </summary>
        public ConcurrentDictionary<string, JogoDomino> Jogos { get; }

        /// <summary>
        /// Fila de espera de jogadores para iniciar partida
        /// </summary>
        public ConcurrentDictionary<string, string> FilaEsperaJogadores { get; } 

        public DominoManager()
        {
            Jogos = new ConcurrentDictionary<string, JogoDomino>();
            FilaEsperaJogadores = new ConcurrentDictionary<string, string>();
        }
        
        /// <summary>
        /// Cria nova instância do jogo, incializando com os jogadores
        /// </summary>
        /// <param name="jogadores"></param>
        /// <returns></returns>
        public JogoDomino CriarJogo(params string[] jogadores)
        {
            var jogo = JogoDomino.NovoJogo(jogadores);
            Jogos.TryAdd(jogo.Id, jogo);

            foreach (var j in jogadores)
                RemoverJogadorDaFila(j);

            return jogo;
        }

        /// <summary>
        /// Recupera uma sessão de jogo em memória
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        public JogoDomino ObterJogo(string idJogo)
        {
            JogoDomino jogo;
            Jogos.TryGetValue(idJogo, out jogo);
            return jogo;
        }


        /// <summary>
        /// Controla a fila de espera de jogadores
        /// </summary>
        /// <param name="jogador"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public bool AdicionarJogadorFilaEspera(string jogador, string connectionId)
        {
            return FilaEsperaJogadores.TryAdd(jogador, connectionId);
        }

        /// <summary>
        /// Recupera o próximo jogador na fila de espera, devolvendo o id do oponente se houver
        /// </summary>
        /// <returns></returns>
        public Tuple<string, string> ProximoNaFila()
        {
            if (FilaEsperaJogadores.IsEmpty) return null;

            string idConnJogador;
            var jogador = FilaEsperaJogadores.First().Key;
            FilaEsperaJogadores.TryRemove(jogador, out idConnJogador);

            return Tuple.Create(jogador, idConnJogador);
        }

        /// <summary>
        /// Tenta remover um jogador específico da fila de espera
        /// </summary>
        /// <param name="jogador"></param>
        /// <returns></returns>
        public string RemoverJogadorDaFila(string jogador)
        {
            string id;
            return FilaEsperaJogadores.TryRemove(jogador, out id) ? id : null;
        }
    }
}
