﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "IStringCounterService")]
public interface IStringCounterService
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStringCounterService/Count", ReplyAction = "http://tempuri.org/IStringCounterService/CountResponse")]
    int Count(string text, string requestedString);

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/IStringCounterService/Count", ReplyAction = "http://tempuri.org/IStringCounterService/CountResponse")]
    System.Threading.Tasks.Task<int> CountAsync(string text, string requestedString);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IStringCounterServiceChannel : IStringCounterService, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class StringCounterServiceClient : System.ServiceModel.ClientBase<IStringCounterService>, IStringCounterService
{

    public StringCounterServiceClient()
    {
    }

    public StringCounterServiceClient(string endpointConfigurationName) :
        base(endpointConfigurationName)
    {
    }

    public StringCounterServiceClient(string endpointConfigurationName, string remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public StringCounterServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
        base(endpointConfigurationName, remoteAddress)
    {
    }

    public StringCounterServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
        base(binding, remoteAddress)
    {
    }

    public int Count(string text, string requestedString)
    {
        return base.Channel.Count(text, requestedString);
    }

    public System.Threading.Tasks.Task<int> CountAsync(string text, string requestedString)
    {
        return base.Channel.CountAsync(text, requestedString);
    }
}
