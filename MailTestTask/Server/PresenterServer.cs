using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Transfer;

namespace Server
{
    class PresenterServer
    {
        private readonly IViewServer view;
        private readonly IModelServer model;
        bool blnStartStop;
        ServiceHost host;
        readonly TransferService transferService = new TransferService();

        public PresenterServer(IViewServer view, IModelServer model)
        {
            this.view = view;
            this.model = model;
            TransferService.Message += TransferService_Message;
        }

        private void TransferService_Message(Data.TransferMessage[] transferMessage, object sender)
        {
            //получение сообщений севером
            try
            {
                model.Save(transferMessage);
                view.ShowEnterMessage(transferMessage);
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
            }

            return;
        }

        public void PrintData()
        {
            //печатаем сообщения
            try
            {
                view.PrintData(model.GetData());
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
            }
        }

        public void StartStopServer()
        {
            //Запуск/останов сервера
            blnStartStop = !blnStartStop;
            if (blnStartStop)
            {
                host = new ServiceHost(typeof(TransferService));
                host.Open();
            }
            else
            {
                host.Close();
            }
            view.ChangeBtnStartStop(blnStartStop);
        }
    }
}
