﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WcfClimas.CoordenadasReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="CoordenadasReference.ICoordenadasService")]
    public interface ICoordenadasService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoordenadasService/ObtenerCoordenadas", ReplyAction="http://tempuri.org/ICoordenadasService/ObtenerCoordenadasResponse")]
        string ObtenerCoordenadas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICoordenadasService/ObtenerCoordenadas", ReplyAction="http://tempuri.org/ICoordenadasService/ObtenerCoordenadasResponse")]
        System.Threading.Tasks.Task<string> ObtenerCoordenadasAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICoordenadasServiceChannel : WcfClimas.CoordenadasReference.ICoordenadasService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CoordenadasServiceClient : System.ServiceModel.ClientBase<WcfClimas.CoordenadasReference.ICoordenadasService>, WcfClimas.CoordenadasReference.ICoordenadasService {
        
        public CoordenadasServiceClient() {
        }
        
        public CoordenadasServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CoordenadasServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoordenadasServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CoordenadasServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string ObtenerCoordenadas() {
            return base.Channel.ObtenerCoordenadas();
        }
        
        public System.Threading.Tasks.Task<string> ObtenerCoordenadasAsync() {
            return base.Channel.ObtenerCoordenadasAsync();
        }
    }
}
