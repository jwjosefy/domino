using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoApp.DomainModel.Common
{
    /// <summary>
    /// Modelo das configurações do Backoffice
    /// </summary>
    /// <remarks>
    /// Esta classe representa o modelo que irá guardar todas
    /// as configurações do sistema
    /// </remarks>
    public class DominoSettings
    {
        /// <summary>
        /// Pontuação que o usuário ganhará ao se cadastrar no jogo
        /// </summary>
        public int BonusNovoCadastro { get; set; }
        
        /// <summary>
        /// Pontuação que o usuário ganhará por logins consecutivos
        /// </summary>
        public int LoginStreakBonus { get; set; }

        /// <summary>
        /// Qtd de dias consecutivos que o usuário precisa logar para ganhar o bônus
        /// </summary>
        public int LoginStreakQtdDias { get; set; }

        /// <summary>
        /// Qtd de pontos que o usuário ganha por cada amigo indicado por email
        /// </summary>
        public int BonusEmailAmigo { get; set; }

        /// <summary>
        /// Pontuação que o usuário ganhará por vitórias consecutivas
        /// </summary>
        public int VitoriaSeguidaBonus { get; set; }

        /// <summary>
        /// Qtd de vitórias consecutivas necessárias para o usuário ganhar o bônus
        /// </summary>
        public int VitoriaSeguidaQtd { get; set; }

        /// <summary>
        /// Qtd mínima de créditos que o usuário precisa comprar para eliminar as propagandas
        /// </summary>
        public int CompraMinimaRemovePropaganda { get; set; }

        /// <summary>
        /// Qtd de dias que o usuário não verá as propagandas após fazer uma compra
        /// </summary>
        public int DiasSemPropaganda { get; set; }
    }
}
