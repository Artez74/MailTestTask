using System.ServiceModel;

namespace Transfer
{
    [ServiceContract]
    interface ITransfer
    {
        [OperationContract]
        int SaveData(TransferMessage dataMessage, string ip);

    }
}
