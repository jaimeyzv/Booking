﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFMemberTests.MiembrosWS {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Miembro", Namespace="http://schemas.datacontract.org/2004/07/WCFMember.Dominio")]
    [System.SerializableAttribute()]
    public partial class Miembro : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ActivoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoMaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ApellidoPaternoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DniField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int EdadField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int MiembroIdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NombresField;
        
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
        public bool Activo {
            get {
                return this.ActivoField;
            }
            set {
                if ((this.ActivoField.Equals(value) != true)) {
                    this.ActivoField = value;
                    this.RaisePropertyChanged("Activo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoMaterno {
            get {
                return this.ApellidoMaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoMaternoField, value) != true)) {
                    this.ApellidoMaternoField = value;
                    this.RaisePropertyChanged("ApellidoMaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ApellidoPaterno {
            get {
                return this.ApellidoPaternoField;
            }
            set {
                if ((object.ReferenceEquals(this.ApellidoPaternoField, value) != true)) {
                    this.ApellidoPaternoField = value;
                    this.RaisePropertyChanged("ApellidoPaterno");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Dni {
            get {
                return this.DniField;
            }
            set {
                if ((object.ReferenceEquals(this.DniField, value) != true)) {
                    this.DniField = value;
                    this.RaisePropertyChanged("Dni");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Edad {
            get {
                return this.EdadField;
            }
            set {
                if ((this.EdadField.Equals(value) != true)) {
                    this.EdadField = value;
                    this.RaisePropertyChanged("Edad");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int MiembroId {
            get {
                return this.MiembroIdField;
            }
            set {
                if ((this.MiembroIdField.Equals(value) != true)) {
                    this.MiembroIdField = value;
                    this.RaisePropertyChanged("MiembroId");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Nombres {
            get {
                return this.NombresField;
            }
            set {
                if ((object.ReferenceEquals(this.NombresField, value) != true)) {
                    this.NombresField = value;
                    this.RaisePropertyChanged("Nombres");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/WCFMember.Errores")]
    [System.SerializableAttribute()]
    public partial class RepetidoException : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CodigoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string DescripcionField;
        
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
        public string Codigo {
            get {
                return this.CodigoField;
            }
            set {
                if ((object.ReferenceEquals(this.CodigoField, value) != true)) {
                    this.CodigoField = value;
                    this.RaisePropertyChanged("Codigo");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Descripcion {
            get {
                return this.DescripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescripcionField, value) != true)) {
                    this.DescripcionField = value;
                    this.RaisePropertyChanged("Descripcion");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MiembrosWS.IMiembrosService")]
    public interface IMiembrosService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ObtenerMiembro", ReplyAction="http://tempuri.org/IMiembrosService/ObtenerMiembroResponse")]
        WCFMemberTests.MiembrosWS.Miembro ObtenerMiembro(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ObtenerMiembro", ReplyAction="http://tempuri.org/IMiembrosService/ObtenerMiembroResponse")]
        System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> ObtenerMiembroAsync(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/CrearMiembro", ReplyAction="http://tempuri.org/IMiembrosService/CrearMiembroResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WCFMemberTests.MiembrosWS.RepetidoException), Action="http://tempuri.org/IMiembrosService/CrearMiembroRepetidoExceptionFault", Name="RepetidoException", Namespace="http://schemas.datacontract.org/2004/07/WCFMember.Errores")]
        WCFMemberTests.MiembrosWS.Miembro CrearMiembro(WCFMemberTests.MiembrosWS.Miembro miembro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/CrearMiembro", ReplyAction="http://tempuri.org/IMiembrosService/CrearMiembroResponse")]
        System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> CrearMiembroAsync(WCFMemberTests.MiembrosWS.Miembro miembro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ModificarMiembro", ReplyAction="http://tempuri.org/IMiembrosService/ModificarMiembroResponse")]
        WCFMemberTests.MiembrosWS.Miembro ModificarMiembro(WCFMemberTests.MiembrosWS.Miembro miembro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ModificarMiembro", ReplyAction="http://tempuri.org/IMiembrosService/ModificarMiembroResponse")]
        System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> ModificarMiembroAsync(WCFMemberTests.MiembrosWS.Miembro miembro);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/EliminarMiembro", ReplyAction="http://tempuri.org/IMiembrosService/EliminarMiembroResponse")]
        void EliminarMiembro(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/EliminarMiembro", ReplyAction="http://tempuri.org/IMiembrosService/EliminarMiembroResponse")]
        System.Threading.Tasks.Task EliminarMiembroAsync(string dni);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ListarMiembros", ReplyAction="http://tempuri.org/IMiembrosService/ListarMiembrosResponse")]
        WCFMemberTests.MiembrosWS.Miembro[] ListarMiembros();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMiembrosService/ListarMiembros", ReplyAction="http://tempuri.org/IMiembrosService/ListarMiembrosResponse")]
        System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro[]> ListarMiembrosAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMiembrosServiceChannel : WCFMemberTests.MiembrosWS.IMiembrosService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MiembrosServiceClient : System.ServiceModel.ClientBase<WCFMemberTests.MiembrosWS.IMiembrosService>, WCFMemberTests.MiembrosWS.IMiembrosService {
        
        public MiembrosServiceClient() {
        }
        
        public MiembrosServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MiembrosServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiembrosServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MiembrosServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WCFMemberTests.MiembrosWS.Miembro ObtenerMiembro(string dni) {
            return base.Channel.ObtenerMiembro(dni);
        }
        
        public System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> ObtenerMiembroAsync(string dni) {
            return base.Channel.ObtenerMiembroAsync(dni);
        }
        
        public WCFMemberTests.MiembrosWS.Miembro CrearMiembro(WCFMemberTests.MiembrosWS.Miembro miembro) {
            return base.Channel.CrearMiembro(miembro);
        }
        
        public System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> CrearMiembroAsync(WCFMemberTests.MiembrosWS.Miembro miembro) {
            return base.Channel.CrearMiembroAsync(miembro);
        }
        
        public WCFMemberTests.MiembrosWS.Miembro ModificarMiembro(WCFMemberTests.MiembrosWS.Miembro miembro) {
            return base.Channel.ModificarMiembro(miembro);
        }
        
        public System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro> ModificarMiembroAsync(WCFMemberTests.MiembrosWS.Miembro miembro) {
            return base.Channel.ModificarMiembroAsync(miembro);
        }
        
        public void EliminarMiembro(string dni) {
            base.Channel.EliminarMiembro(dni);
        }
        
        public System.Threading.Tasks.Task EliminarMiembroAsync(string dni) {
            return base.Channel.EliminarMiembroAsync(dni);
        }
        
        public WCFMemberTests.MiembrosWS.Miembro[] ListarMiembros() {
            return base.Channel.ListarMiembros();
        }
        
        public System.Threading.Tasks.Task<WCFMemberTests.MiembrosWS.Miembro[]> ListarMiembrosAsync() {
            return base.Channel.ListarMiembrosAsync();
        }
    }
}
