using System.Collections.Generic;

namespace Data
{
    public interface IWorker
    {
        void Save(TransferMessage message);
        IEnumerable<PrintMessage> GetData();
    }
}
