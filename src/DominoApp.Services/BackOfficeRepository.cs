using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominoApp.DomainModel.Common;

namespace DominoApp.Services
{
    public class BackOfficeRepository
    {
        /// <summary>
        /// Retorna o objeto com todas as configurações globais do jogo
        /// </summary>
        /// <returns></returns>
        public DominoSettings GetDominoSettings()
        {
            // TODO Implementar acesso ao BD

            // Esse objeto fake só é retornado com valores chumbados para poder testar a tela
            // TODO REMOVER O OBJETO ABAIXO APÓS IMPLEMENTAR ACESSO AO BD
            return new DominoSettings()
            {
                BonusEmailAmigo = 10,
                BonusNovoCadastro = 50,
                CompraMinimaRemovePropaganda = 100,
                DiasSemPropaganda = 20,
                LoginStreakBonus=50,
                LoginStreakQtdDias = 3,
                VitoriaSeguidaBonus = 50,
                VitoriaSeguidaQtd = 5
            };
        }

        /// <summary>
        /// Grava no BD as configurações globais do jogo
        /// </summary>
        /// <param name="settings"></param>
        public void SaveDominoSettings(DominoSettings settings)
        {
            // TODO Implementar gravação no BD
        }

    }
}
