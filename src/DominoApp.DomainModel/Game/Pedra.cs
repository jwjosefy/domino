using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.DomainModel.Game
{
    public class Pedra
    {
        public int Lado1 { get; }
        public int Lado2 { get; }

        public Pedra(int lado1, int lado2)
        {
            if (lado1 < 0 || lado1 > 6 || lado2 < 0 || lado2 > 6)
                throw new ArgumentException("lado deve ser entre 0 e 6");

            Lado1 = Math.Min(lado1, lado2);
            Lado2 = Math.Max(lado1, lado2);
        }

        /// <summary>
        /// Testa se a pedra pode encaixar com outra baseado nos pontos
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool PodeJogar(int p)
        {
            return Lado1 == p || Lado2 == p;
        }

        /// <summary>
        /// Devolve qual é a ponta livre desta pedra, comparada à outra pedra
        /// </summary>
        /// <param name="pedra2"></param>
        /// <returns></returns>
        public int PontaLivre(Pedra pedra2)
        {
            if (Lado1 == pedra2.Lado1 || Lado1 == pedra2.Lado2) return Lado2;
            if (Lado2 == pedra2.Lado1 || Lado2 == pedra2.Lado2) return Lado1;

            // Pedras não tem lados iguais, devolve -1 como erro
            return -1;
        }

        public static Pedra FromString(string pedra)
        {
            var lados = pedra.Split('x').Select(x => Convert.ToInt32(x)).ToList();
            return new Pedra(lados[0], lados[1]);
        }

        public override string ToString()
        {
            return $"{Lado1}x{Lado2}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Pedra) obj);
        }

        protected bool Equals(Pedra other)
        {
            return Lado1 == other.Lado1 && Lado2 == other.Lado2;
        }

        public override int GetHashCode()
        {
            return (Lado1*397) ^ Lado2;
        }

        public static bool operator ==(Pedra left, Pedra right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pedra left, Pedra right)
        {
            return !Equals(left, right);
        }
    }
}
