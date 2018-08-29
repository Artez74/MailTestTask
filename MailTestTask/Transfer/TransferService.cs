using Data;

namespace Transfer
{
    public delegate void MessageFromClient(TransferMessage transferMessage, object sender);

    public class TransferService : ITransferService
    {
        public static event MessageFromClient Message;
        public int SaveData(TransferMessage dataMessage)
        {
            Message?.Invoke(dataMessage, this);
            return 0;
        }
    }
}
