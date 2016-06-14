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
        public void Jogar(string idJogador, string pedra, string lado)
        {
            var jogador = Jogadores.First(j => j.Id == idJogador);
            jogador.Jogar(pedra);
            var eLado = lado == "e" ? Mesa.Lado.Esquerdo : Mesa.Lado.Direito;
            Mesa.Jogar(Pedra.FromString(pedra), eLado);
        }
    }
}
