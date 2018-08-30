using Data;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Transfer
{
    public delegate void MessageFromClient(TransferMessage[] transferMessage, object sender);

    public class TransferService : ITransferService
    {
        public static event MessageFromClient Message;
        public int SaveData(TransferMessage[] dataMessage)
        {
            OperationContext context = OperationContext.Current;
            MessageProperties prop = context.IncomingMessageProperties;
            RemoteEndpointMessageProperty endpoint = prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
            //получаем IP клиента.
            string ipAddr = endpoint.Address;
            foreach(var item in dataMessage)
            {
                item.ip = ipAddr;
            }
            Message?.Invoke(dataMessage, this);
            return 0;
        }
    }
}
