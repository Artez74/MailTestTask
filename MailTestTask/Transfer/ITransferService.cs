using System.ServiceModel;

namespace Transfer
{
    [ServiceContract]
    interface ITransferService
    {
        [OperationContract]
        int SaveData(TransferMessage dataMessage, string ip);

    }
}
