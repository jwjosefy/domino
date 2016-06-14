using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.DomainModel.Game
{
    public class Jogador
    {
        public Jogador(string idJogador)
        {
            Id = idJogador;
        }

        public string Id { get; set; }

        public List<Pedra> Mao { get; set; }

        /// <summary>
        /// Placar do jogador para a partida atual
        /// </summary>
        public int Pontos { get; set; }

        public void Jogar(string sPedra)
        {
            var pedra = Pedra.FromString(sPedra);
            Mao.Remove(pedra);
        }

        public void Adicionar(Pedra pedra)
        {
            Mao.Add(pedra);
        }
    }
}
