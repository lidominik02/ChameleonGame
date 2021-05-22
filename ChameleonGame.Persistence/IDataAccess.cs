using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChameleonGame.Persistence
{
    public interface IDataAccess
    {
        Task<ChameleonTable> LoadAsync(String path);
        Task SaveAsync(String path, ChameleonTable table);
    }
}
