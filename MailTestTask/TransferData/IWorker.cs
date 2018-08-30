using System.Collections.Generic;

namespace Data
{
    public interface IWorker
    {
        void Save(object[] message);
        IEnumerable<PrintMessage> GetData();
        void Update(object[] message);
    }
}
