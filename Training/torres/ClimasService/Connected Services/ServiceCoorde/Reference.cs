﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClimasService.ServiceCoorde {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceCoorde.IServiceCoordenada")]
    public interface IServiceCoordenada {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCoordenada/Coordenada", ReplyAction="http://tempuri.org/IServiceCoordenada/CoordenadaResponse")]
        object Coordenada();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceCoordenada/Coordenada", ReplyAction="http://tempuri.org/IServiceCoordenada/CoordenadaResponse")]
        System.Threading.Tasks.Task<object> CoordenadaAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceCoordenadaChannel : ClimasService.ServiceCoorde.IServiceCoordenada, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceCoordenadaClient : System.ServiceModel.ClientBase<ClimasService.ServiceCoorde.IServiceCoordenada>, ClimasService.ServiceCoorde.IServiceCoordenada {
        
        public ServiceCoordenadaClient() {
        }
        
        public ServiceCoordenadaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceCoordenadaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCoordenadaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceCoordenadaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public object Coordenada() {
            return base.Channel.Coordenada();
        }
        
        public System.Threading.Tasks.Task<object> CoordenadaAsync() {
            return base.Channel.CoordenadaAsync();
        }
    }
}
