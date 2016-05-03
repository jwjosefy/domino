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
        public DominoSettings GetDominoSettings()
        {
            throw new NotImplementedException("IMPLEMENTAR O ACESSO AO BD");
        }

        public void SaveDominoSettings(DominoSettings settings)
        {
            throw new NotImplementedException("Criar gravação no BD");
        }

    }
}
