﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Client.TransferService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TransferService.ITransferService")]
    public interface ITransferService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransferService/SaveData", ReplyAction="http://tempuri.org/ITransferService/SaveDataResponse")]
        int SaveData(Data.TransferMessage[] dataMessage);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITransferService/SaveData", ReplyAction="http://tempuri.org/ITransferService/SaveDataResponse")]
        System.Threading.Tasks.Task<int> SaveDataAsync(Data.TransferMessage[] dataMessage);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITransferServiceChannel : Client.TransferService.ITransferService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TransferServiceClient : System.ServiceModel.ClientBase<Client.TransferService.ITransferService>, Client.TransferService.ITransferService {
        
        public TransferServiceClient() {
        }
        
        public TransferServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TransferServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TransferServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TransferServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int SaveData(Data.TransferMessage[] dataMessage) {
            return base.Channel.SaveData(dataMessage);
        }
        
        public System.Threading.Tasks.Task<int> SaveDataAsync(Data.TransferMessage[] dataMessage) {
            return base.Channel.SaveDataAsync(dataMessage);
        }
    }
}
