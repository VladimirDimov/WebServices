﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleClient.DayOfWeekServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="DayOfWeekServiceReference.IDayOfWeekService")]
    public interface IDayOfWeekService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfWeekService/Today", ReplyAction="http://tempuri.org/IDayOfWeekService/TodayResponse")]
        string Today();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDayOfWeekService/Today", ReplyAction="http://tempuri.org/IDayOfWeekService/TodayResponse")]
        System.Threading.Tasks.Task<string> TodayAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDayOfWeekServiceChannel : ConsoleClient.DayOfWeekServiceReference.IDayOfWeekService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DayOfWeekServiceClient : System.ServiceModel.ClientBase<ConsoleClient.DayOfWeekServiceReference.IDayOfWeekService>, ConsoleClient.DayOfWeekServiceReference.IDayOfWeekService {
        
        public DayOfWeekServiceClient() {
        }
        
        public DayOfWeekServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public DayOfWeekServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfWeekServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public DayOfWeekServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Today() {
            return base.Channel.Today();
        }
        
        public System.Threading.Tasks.Task<string> TodayAsync() {
            return base.Channel.TodayAsync();
        }
    }
}