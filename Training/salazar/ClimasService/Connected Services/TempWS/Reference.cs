﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClimasService.TempWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/TemperaturasService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="TempWS.ITemperaturaService")]
    public interface ITemperaturaService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/GetData", ReplyAction="http://tempuri.org/ITemperaturaService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/GetData", ReplyAction="http://tempuri.org/ITemperaturaService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITemperaturaService/GetDataUsingDataContractResponse")]
        ClimasService.TempWS.CompositeType GetDataUsingDataContract(ClimasService.TempWS.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/GetDataUsingDataContract", ReplyAction="http://tempuri.org/ITemperaturaService/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<ClimasService.TempWS.CompositeType> GetDataUsingDataContractAsync(ClimasService.TempWS.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/ObtenerTemperatura", ReplyAction="http://tempuri.org/ITemperaturaService/ObtenerTemperaturaResponse")]
        int ObtenerTemperatura();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ITemperaturaService/ObtenerTemperatura", ReplyAction="http://tempuri.org/ITemperaturaService/ObtenerTemperaturaResponse")]
        System.Threading.Tasks.Task<int> ObtenerTemperaturaAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ITemperaturaServiceChannel : ClimasService.TempWS.ITemperaturaService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class TemperaturaServiceClient : System.ServiceModel.ClientBase<ClimasService.TempWS.ITemperaturaService>, ClimasService.TempWS.ITemperaturaService {
        
        public TemperaturaServiceClient() {
        }
        
        public TemperaturaServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public TemperaturaServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemperaturaServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public TemperaturaServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public ClimasService.TempWS.CompositeType GetDataUsingDataContract(ClimasService.TempWS.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<ClimasService.TempWS.CompositeType> GetDataUsingDataContractAsync(ClimasService.TempWS.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public int ObtenerTemperatura() {
            return base.Channel.ObtenerTemperatura();
        }
        
        public System.Threading.Tasks.Task<int> ObtenerTemperaturaAsync() {
            return base.Channel.ObtenerTemperaturaAsync();
        }
    }
}