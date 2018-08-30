using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.TransferService;
using Data;

namespace Client
{
    class ModelClient : IModelClient
    {
        readonly IWorker worker;
        public ModelClient(IWorker saver)
        {
            this.worker = saver;
        }

        public IEnumerable<string> GetData()
        {
            //получаем неотправленные сообщения
            return worker.GetData().Select(x => x.Message);
        }

        public void Save(ClientMessage[] clientMessage)
        {         
            //сохраняем отпрвленные сообщения
            worker.Save(clientMessage);
        }
        public void Update()
        {
            //обновляем файл после отправки сообщений, которые не были отправлены сразу
            worker.Update(null);
        }
    }
}
