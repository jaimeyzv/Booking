﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClimasService.ServiceTemp {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceTemp.IServiceTemperatura")]
    public interface IServiceTemperatura {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTemperatura/Temperatura", ReplyAction="http://tempuri.org/IServiceTemperatura/TemperaturaResponse")]
        int Temperatura();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceTemperatura/Temperatura", ReplyAction="http://tempuri.org/IServiceTemperatura/TemperaturaResponse")]
        System.Threading.Tasks.Task<int> TemperaturaAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceTemperaturaChannel : ClimasService.ServiceTemp.IServiceTemperatura, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceTemperaturaClient : System.ServiceModel.ClientBase<ClimasService.ServiceTemp.IServiceTemperatura>, ClimasService.ServiceTemp.IServiceTemperatura {
        
        public ServiceTemperaturaClient() {
        }
        
        public ServiceTemperaturaClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceTemperaturaClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTemperaturaClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceTemperaturaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int Temperatura() {
            return base.Channel.Temperatura();
        }
        
        public System.Threading.Tasks.Task<int> TemperaturaAsync() {
            return base.Channel.TemperaturaAsync();
        }
    }
}