﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication5.ServiceReference2 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IService2")]
    public interface IService2 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/GetMoneyFromImperium", ReplyAction="http://tempuri.org/IService2/GetMoneyFromImperiumResponse")]
        int GetMoneyFromImperium();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService2/GetMoneyFromImperium", ReplyAction="http://tempuri.org/IService2/GetMoneyFromImperiumResponse")]
        System.Threading.Tasks.Task<int> GetMoneyFromImperiumAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService2Channel : ConsoleApplication5.ServiceReference2.IService2, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service2Client : System.ServiceModel.ClientBase<ConsoleApplication5.ServiceReference2.IService2>, ConsoleApplication5.ServiceReference2.IService2 {
        
        public Service2Client() {
        }
        
        public Service2Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service2Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service2Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetMoneyFromImperium() {
            return base.Channel.GetMoneyFromImperium();
        }
        
        public System.Threading.Tasks.Task<int> GetMoneyFromImperiumAsync() {
            return base.Channel.GetMoneyFromImperiumAsync();
        }
    }
}
