using System;
using System.Collections.Generic;
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
    }
}
