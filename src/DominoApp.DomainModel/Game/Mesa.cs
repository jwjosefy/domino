using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.DomainModel.Game
{
    /// <summary>
    /// Mesa precisa controlar a sequencia das pedras jogadas
    /// e quais são as pontas esquerda e direita.
    /// Também precisa controlar a pilha de pedras para comprar.
    /// </summary>
    public class Mesa
    {
        #region Propriedades

        /// <summary>
        /// Quais foram as pedras jogadas (uso interno)
        /// </summary>
        private LinkedList<Pedra> _pedrasJogadas;

        /// <summary>
        /// Quais foram as pedras jogadas
        /// </summary>
        /// <remarks>Não permite que classes externas modifiquem a mesa</remarks>
        public IReadOnlyList<Pedra> PedrasJogadas => _pedrasJogadas.ToList();

        /// <summary>
        /// Monte de pedras que podem ser compradas
        /// </summary>
        public Stack<Pedra> Monte { get; set; }

        public int PontaEsquerda => ObterPonta(Lado.Esquerdo);
        public int PontaDireita => ObterPonta(Lado.Direito);

        #endregion

        public Mesa()
        {
            IniciarMesa();
        }

        /// <summary>
        /// (Re)inicia a mesa
        /// </summary>
        public void IniciarMesa()
        {
            _pedrasJogadas = new LinkedList<Pedra>();

            // inicia as 28 pedras
            var pedras = new List<Pedra>();

            for (var i = 0; i <= 6; i++)
                for (var j = i; j <= 6; j++)
                    pedras.Add(new Pedra(i, j));

            // coloca as 28 pedras misturadas
            var r = new Random();
            Monte = new Stack<Pedra>(pedras.OrderBy(p => r.Next()));
        }

        /// <summary>
        /// Usada para iniciar a mão dos jogadores ou qnd não tem mais pedras
        /// </summary>
        /// <returns></returns>
        public Pedra ComprarPedra()
        {
            return Monte.Count == 0 ? null : Monte.Pop();
        }

        /// <summary>
        /// Devolve uma mão inicial com 7 pedras para um jogador
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public List<Pedra> ComprarMao(int count = 7)
        {
            var mao = Monte.Take(count).ToList();
            Monte = new Stack<Pedra>(Monte.Skip(count));
            return mao;
        } 

        /// <summary>
        /// Executa uma jogada, adicionando a pedra na mesa em alguma ponta
        /// </summary>
        /// <param name="pedra">Qual é a pedra</param>
        /// <param name="lado">Em qual ponta a pedra será jogada</param>
        public void Jogar(Pedra pedra, Lado lado)
        {
            if (_pedrasJogadas.Count == 0)
            {
                _pedrasJogadas.AddFirst(pedra);
                return;
            }

            var ponta = ObterPonta(lado);

            if (!pedra.PodeJogar(ponta))
                throw new InvalidOperationException($"Não pode jogar a pedra {pedra} numa ponta {ponta}, lado {lado}");

            if (lado == Lado.Esquerdo)
            {
                _pedrasJogadas.AddFirst(pedra);
            }
            else
            {
                _pedrasJogadas.AddLast(pedra);
            }
        }

        private int ObterPonta(Lado lado)
        {
            if (_pedrasJogadas.Count == 0)
                return -1;

            if (_pedrasJogadas.Count == 1)
            {
                var pedra = _pedrasJogadas.First.Value;

                // Sempre devolve o maior lado como sendo a ponta da esquerda
                // para iniciar o jogo.
                // 'Pedra' é definido para ter sempre o Lado2 >= Lado1

                return lado == Lado.Esquerdo ? pedra.Lado2 : pedra.Lado1;
            }

            int ponta;

            if (lado == Lado.Esquerdo)
            {
                var pedraPonta = _pedrasJogadas.First.Value;
                ponta = pedraPonta.PontaLivre(_pedrasJogadas.First.Next?.Value);
            }
            else
            {
                var pedraPonta = _pedrasJogadas.Last.Value;
                ponta = pedraPonta.PontaLivre(_pedrasJogadas.Last.Previous?.Value);
            }

            return ponta;
        }

        /// <summary>
        /// Pontas da mesa de dominó
        /// </summary>
        public enum Lado
        {
            Esquerdo,
            Direito
        }
    }
}
