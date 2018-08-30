using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;

namespace Server
{
    class ModelServer : IModelServer
    {
        readonly IWorker saver;
        public ModelServer(IWorker saver)
        {
            this.saver = saver;
        }

        public IEnumerable<PrintMessage> GetData()
        {
            //получаем данные для печати
            return saver.GetData();
        }

        public void Save(TransferMessage[] transferMessage)
        {
            //сохраняем в базу
            saver.Save(transferMessage);
        }
    }
}
