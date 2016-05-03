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
        
        public int LoginStreakBonus { get; set; }

        public int LoginStreakQtd { get; set; }

        public int BonusEmailAmigo { get; set; }

        public int VitoriaSeguidaBonus { get; set; }

        public int VitoriaSeguidaQtd { get; set; }

        public int CompraMinimaRemovePropaganda { get; set; }

        public int DiasSemPropaganda { get; set; }
    }
}
