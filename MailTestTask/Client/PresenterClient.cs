using Client.TransferService;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class PresenterClient
    {
        private readonly IViewClient view;
        private readonly IModelClient model;
        public PresenterClient(IViewClient view, IModelClient model)
        {
            this.view = view;
            this.model = model;
        }
        public async Task SendMessage(string message)
        {
            try
            {
                bool isTransfer = await SendMessageToServer(new string[] { message});
                model.Save(new ClientMessage[] { new ClientMessage() { Message = message, IsTransfer = isTransfer } });
            }
            catch(Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
            }

        }
        private async Task<bool> SendMessageToServer(string[] message)
        {
            //отправляем сообщение на сервер
            return await Task.Run(() =>
            {
                bool IsTransfer = false;
                //String host = System.Net.Dns.GetHostName();
                //System.Net.IPAddress ip = System.Net.Dns.GetHostByName(host).AddressList[0];
                List<TransferMessage> transferMessages = new List<TransferMessage>();
                foreach (var item in message)
                {
                    transferMessages.Add(new TransferMessage()
                    {
                        Message = item
                        //ip = ip.ToString()
                    });
                }
                try
                {
                    var client = new TransferServiceClient("NetTcpBinding_ITransferService");
                    client.SaveData(transferMessages.ToArray());
                    client.Close();
                    IsTransfer = true;
                }
                catch 
                { IsTransfer = false; }
                return IsTransfer;
            });
        }

        public async Task SendUnsendMessage()
        {
            //отправляем неотправленные сообщения на сервер 
            try
            {
                var message = model.GetData();
                if(message.Count()>0)
                    if ((await SendMessageToServer(model.GetData().ToArray())))
                        model.Update();
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage(ex.Message);
            }
        }
    }
}
