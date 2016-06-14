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

        /// <summary>
        /// Adiciona uma pedra comprada na mão do jogador
        /// </summary>
        /// <param name="pedra"></param>
        public void Adicionar(Pedra pedra)
        {
            Mao.Add(pedra);
        }

        /// <summary>
        /// Verifica quais são as pedras possíveis de serem jogadas para as pontas informadas
        /// </summary>
        /// <param name="pEsquerda"></param>
        /// <param name="pDireita"></param>
        /// <returns></returns>
        public List<Pedra> ObterJogadasPossiveis(int pEsquerda, int pDireita)
        {
            var pontas = new[] {pEsquerda, pDireita};

            return Mao
                .Where(p => pontas.Contains(p.Lado1) || pontas.Contains(p.Lado2))
                .ToList();
        }
    }
}
